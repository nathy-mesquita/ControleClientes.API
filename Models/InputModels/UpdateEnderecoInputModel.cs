using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using ControleClientes.API.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace ControleClientes.API.Models.InputModels
{
    public class UpdateEnderecoInputModel
    {
        [Required(ErrorMessage = "Tipo endereço Obrigatório!")]
        public TipoEndereco Tipo { get; set; }

        [Required(ErrorMessage = "Número Obrigatório!")]
        public int Numero { get; set; }
 
        public string Complemento { get; set; }

        [StringLength(8, ErrorMessage = "CEP inválido!")]
        public string Cep { get; set; }
    }
}
