using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using ControleClientes.API.Core.Entities;

namespace ControleClientes.API.Models.ViewModels
{
    public class EnderecoViewModel
    {
        public EnderecoViewModel(TipoEndereco tipo, string logradouro, int numero, string complemento, string bairro, string cidade, string estado, string cep, int idPessoa)
        {
            Tipo = tipo;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            IdPessoa = idPessoa;
        }

        public TipoEndereco Tipo { get; set; }
        public string Logradouro { get; private set; }
        public int Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Cep { get; private set; }
        public int IdPessoa { get; private set; }
    }
}
