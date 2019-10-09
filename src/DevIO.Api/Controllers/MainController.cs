using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DevIO.Api.ViewModels;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DevIO.Api.Controllers {

    [ApiController]
    public abstract class MainController : ControllerBase {
        private readonly INotificador _noticador;

        public MainController(INotificador notificador)
        {
            _noticador = notificador;
        }

        protected bool OperacaoValida() 
        {
            return !_noticador.TemNotificacao();

        }
        
        protected ActionResult CustomResponse(ModelStateDictionary modelState) 
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return CustomResponse();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new {
                success = false,
                errors = _noticador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(erroMsg);
            }
        }

        protected void NotificarErro(string erroMsg)
        {
            _noticador.Handle(new Notificacao(erroMsg));
        }
    }

}