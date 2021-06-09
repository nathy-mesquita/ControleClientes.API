using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ControleClientes.API.Core.Entities
{
    public class Endereco : BaseEntity
    {
        public Endereco(TipoEndereco tipo, string logradouro, int numero, string complemento, string bairro, string cidade, string estado, string cep, int idPessoa) : base()
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
        public string Logradouro { get;  set; }
        public int Numero { get;  set; }
        public string Complemento { get;  set; }
        public string Bairro { get;  set; }
        public string Cidade { get;  set; }
        public string Estado { get;  set; }
        public string Cep { get;  set; }
        public int IdPessoa { get;  set; }

        public void UpdateEndereco(TipoEndereco tipo, string logradouro, int numero, string complemento, string bairro, string cidade, string estado, string cep, int idPessoa)
        {
            Tipo = tipo;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            IdPessoa = idPessoa;
        }

    }
}
