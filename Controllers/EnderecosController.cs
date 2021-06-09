using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using ControleClientes.API.Persistence;
using ControleClientes.API.Core.Entities;
using ControleClientes.API.Models.ViewModels;
using ControleClientes.API.Models.InputModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ControleClientes.API.Controllers
{
    [ApiController, Route("[controller]")]
    public class EnderecosController : BaseController
    {
        private readonly ControleClientesDbContext _dbContext;
        public EnderecosController(ControleClientesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Obtêm dados de endereço de uma pessoa
        /// </summary>
        /// <param name="idPessoa">Identicador da pessoa</param>
        /// <returns>Retorna todos endereços de ima pessoa</returns>
        [HttpGet]
        public IActionResult GetAll(int idPessoa)
        {
            var allEnderecos = _dbContext.Enderecos.Where(e => e.IdPessoa == idPessoa && e.Ativo);

            var allEnderecoViewModels = allEnderecos
                .Select(e => new EnderecoViewModel(e.Tipo, e.Logradouro, e.Numero, e.Complemento, e.Bairro, e.Cidade, e.Estado, e.Cep, e.IdPessoa));

            return Ok(allEnderecoViewModels);
        }

        /// <summary>
        /// Obtêm um endereço
        /// </summary>
        /// <param name="idPessoa">Identificador da pessoa</param>
        /// <param name="enderecoId">Identificador endereço</param>
        /// <returns>Retorna um objeto de endereço</returns>
        [HttpGet("{enderecoId}")]
        public IActionResult Get(int idPessoa, int enderecoId)
        {
            var endereco = _dbContext.Enderecos.SingleOrDefault(e => e.Id == enderecoId && e.IdPessoa == idPessoa);
            if (endereco == null)
                return NotFound();

            var enderecoViewModel = new EnderecoViewModel(endereco.Tipo, endereco.Logradouro, endereco.Numero, endereco.Complemento, endereco.Bairro, endereco.Cidade, endereco.Estado, endereco.Cep, endereco.IdPessoa);
            return Ok(enderecoViewModel);
        }
        
        /// <summary>
        /// Cria um endereço
        /// </summary>
        /// <param name="idPessoa">Identificador da pessoa</param>
        /// <param name="inputModel">Objeto de endereço</param>
        /// <returns>Mostra o objeto criado</returns>
        [HttpPost]
        public IActionResult Post(int idPessoa, [FromBody] CreateEnderecoInputModel inputModel)
        {
            //TODO: Não será permitido o cadastro de dois endereços com o mesmo tipo para a mesma pessoa
            var endereco = new Endereco(inputModel.Tipo, inputModel.Logradouro, inputModel.Numero, inputModel.Complemento, inputModel.Bairro, inputModel.Cidade, inputModel.Estado, inputModel.Cep, inputModel.IdPessoa);
            
            if (ModelState.IsValid)
            {
                _dbContext.Enderecos.Add(endereco);
                _dbContext.SaveChanges();
                return CreatedAtAction(nameof(Get), new { idPessoa = endereco.IdPessoa, enderecoId = endereco.Id }, inputModel);
            }
            return BadRequest();
        }

        /// <summary>
        /// Atualiza endereço
        /// </summary>
        /// <param name="idPessoa">Identificador da pessoa</param>
        /// <param name="enderecoId">Identificador do endereço</param>
        /// <param name="inputModel">Objeto de endereço para atualização</param>
        /// <returns>Mostra o endereço atualizado</returns>
        [HttpPut("{enderecoId}")]
        public IActionResult Put(int idPessoa, int enderecoId, [FromBody] UpdateEnderecoInputModel inputModel)
        {
            var endereco = _dbContext.Enderecos.SingleOrDefault(e => e.IdPessoa == idPessoa && e.Id == enderecoId);
            if (endereco == null)
                return NotFound();
            if (ModelState.IsValid)
            {
                var api = BuscarCep(long.Parse(endereco.Cep));
                endereco.UpdateEndereco(inputModel.Tipo, api.Street, inputModel.Numero, inputModel.Complemento, api.Neighborhood, api.City, api.State, inputModel.Cep, idPessoa);
                _dbContext.SaveChanges();
                return NoContent();
            }
            return BadRequest();
        }

        /// <summary>
        /// Desativa um endereço
        /// </summary>
        /// <param name="idPessoa">Identificador da pessoa</param>
        /// <param name="enderecoId">Identificador do endereço</param>
        /// <returns>Retorna objeto com estatus desativado</returns>
        [HttpDelete ("{enderecoId}")]
        public IActionResult Delete(int idPessoa, int enderecoId)
        {
            var endereco = _dbContext.Enderecos.SingleOrDefault(e => e.IdPessoa == idPessoa && e.Id == enderecoId);

            if (endereco == null)
                return NotFound();

            endereco.Desativar();
            _dbContext.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Obtêm as informações de um cep
        /// </summary>
        /// <param name="cep"></param>
        /// <returns>Retorna um objeto de cep</returns>
        [HttpGet("cep/{cep}")]
        public IActionResult GetCep(long cep) 
        {
            return Ok(BuscarCep(cep));
        }
    }
}
