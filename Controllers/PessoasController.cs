using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ControleClientes.API.Persistence;
using ControleClientes.API.Core.Entities;
using ControleClientes.API.Models.ViewModels;
using ControleClientes.API.Models.InputModels;

namespace ControleClientes.API.Controllers
{
    [Route("api/[controller]")]
    public class PessoasController : BaseController
    {

        private readonly ControleClientesDbContext _dbContext;
        public PessoasController(ControleClientesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Obtêm uma pessoa
        /// </summary>
        /// <param name="cpf">Cpf da pessoa</param>
        /// <returns>Retorna uma pessoa</returns>
        [HttpGet("{cpf}")]
        public IActionResult Get(string cpf)
        {
            var pessoa = _dbContext.Pessoas.SingleOrDefault(p => p.Cpf == cpf);

            if (pessoa == null)
                return NotFound();
            
            var pessoaViewModel = new PessoaViewModel(pessoa.Id, pessoa.Cpf, pessoa.Nome, pessoa.Sobrenome, pessoa.DataNascimento, pessoa.Genero, pessoa.Enderecos);
            return Ok(pessoaViewModel);
        }

        /// <summary>
        /// Cadastra uma pessoa
        /// </summary>
        /// <param name="inputModel">Objeto pessoa</param>
        /// <returns>Retorna pessoa cadastrada</returns>
        [HttpPost]
        public IActionResult Post([FromBody] CreatePessoaInputModel inputModel)
        {
            //TODO: Ter pelo menos um endereço cadastrado
            var pessoa = new Pessoa(inputModel.Nome, inputModel.Sobrenome, inputModel.CPF, inputModel.DataNascimento, inputModel.Genero, inputModel.Enderecos);

            if (ModelState.IsValid)
            {
                var idade = pessoa.CalculaIdade(inputModel.DataNascimento);
                if (idade >= 18)
                {
                    _dbContext.Pessoas.Add(pessoa);
                    _dbContext.SaveChanges();
                    return CreatedAtAction(nameof(Get), new { cpf = pessoa.Cpf }, inputModel);
                }
                else
                {
                    throw new Exception("Pessoa com menos de 18 anos!");
                }
            }
            return BadRequest();
        }

        /// <summary>
        /// Atualiza o cadastro da pessoa
        /// </summary>
        /// <param name="cpf">Cpf da pessoa</param>
        /// <param name="inputModel">objeto da pessoa atualizado</param>
        /// <returns>Retorna o cadastro da pessoa atualizado</returns>
        [HttpPut("{cpf}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Put(string cpf, [FromBody] UpdatePessoaInputModel inputModel)
        {
            var pessoa = _dbContext.Pessoas.SingleOrDefault(p => p.Cpf == cpf);
            if(pessoa == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                var endereco = _dbContext.Enderecos.SingleOrDefault();
                var api = BuscarCep(long.Parse(endereco.Cep));
                //endereco.UpdateEndereco(inputModel.Tipo, api.Street, inputModel.Numero, inputModel.Complemento, api.Neighborhood, api.City, api.State, inputModel.Cep, idPessoa);
                _dbContext.SaveChanges();
                return NoContent();
            }
            //pessoa.Update(inputModel.Enderecos);
            _dbContext.SaveChanges();
            return NoContent();
        }

    }
}
