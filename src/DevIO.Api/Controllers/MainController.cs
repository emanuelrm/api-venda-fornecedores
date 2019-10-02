using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DevIO.Api.ViewModels;
using DevIO.Business.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.Controllers {

    [ApiController]
    public abstract class MainController : ControllerBase
    {
        //validacao da notificacao de Erros

        //validacao de model state

        //validacao da operacao de negocios
    }

    [Route("api/fornecedores")]
    public abstract class FornecedoresController : MainController
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public FornecedoresController(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            this._fornecedorRepository = fornecedorRepository;
            this._mapper = mapper;
        }
        
        public async Task<IEnumerable<FornecedorViewModel>> ObterTodos()
        {
            var fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return fornecedores;
        }    

         public async Task<FornecedorViewModel> ObterPorId(Guid id)
        {
            var fornecedor = _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id));
            return fornecedor;
        }    
    }
}