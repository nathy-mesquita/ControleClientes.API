using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using ControleClientes.API.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace ControleClientes.API.Application.Models.InputModels
{
    public class CreateEnderecoInputModel
    {
        [Required(ErrorMessage = "Tipo endereço Obrigatório!")]
        public TipoEnderecoEnum Tipo { get; set; }

        [Required(ErrorMessage = "Logradouro Obrigatório!")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Número Obrigatório!")]
        public int Numero { get; set; }

        public string Complemento { get; set; }

        [StringLength(8, ErrorMessage = "CEP inválido!")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Bairro Obrigatório!")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Cidade Obrigatório!")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Estado Obrigatório!")]
        public string Estado { get; set; }

        public int IdPessoa { get; set; }
    }
}
