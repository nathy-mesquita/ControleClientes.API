using ControleClientes.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleClientes.API.Application.Models.InputModels
{
    public class UpdateEnderecoInputModel
    {
        [Required(ErrorMessage = "Tipo endereço Obrigatório!")]
        public TipoEnderecoEnum Tipo { get; set; }

        [Required(ErrorMessage = "Número Obrigatório!")]
        public int Numero { get; set; }

        public string Complemento { get; set; }

        [StringLength(8, ErrorMessage = "CEP inválido!")]
        public string Cep { get; set; }
    }
}
