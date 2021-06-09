using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using ControleClientes.API.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace ControleClientes.API.Models.InputModels
{
    public class UpdatePessoaInputModel
    {
        [Required(ErrorMessage = "Cpf Obrigatório!")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Endereço Obrigatório!")]
        public IList<Endereco> Enderecos { get; set; }
    }
}
