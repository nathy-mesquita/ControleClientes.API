using ControleClientes.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleClientes.API.Application.Models.InputModels
{
    public class UpdatePessoaInputModel
    {
        [Required(ErrorMessage = "Cpf Obrigatório!")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Endereço Obrigatório!")]
        public IList<Endereco> Enderecos { get; set; }
    }
}
