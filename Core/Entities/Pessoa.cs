using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ControleClientes.API.Core.Entities
{
    public class Pessoa : BaseEntity
    {
        public Pessoa(string nome, string sobrenome, string cpf, DateTime dataNascimento, char genero, IEnumerable<Endereco> endereco) : base()
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Genero = genero;

            this.Enderecos = new List<Endereco>();
        }

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        //Não será permitido o cadastro de duas ou mais pessoas com o mesmo CPF
        public string Cpf { get; private set; }
        //Não será permitido o cadastro de pessoas menores de 18 anos
        public DateTime DataNascimento { get; private set; }
        //Não é obrigatório
        public char Genero { get; private set; }

        //Não será permitido o cadastro de dois endereços com o mesmo tipo para a mesma pessoa
        public IEnumerable<Endereco> Enderecos { get; set; }


        public int CalculaIdade(DateTime dataNascimento)
        {
            int idade = DateTime.Now.Year - dataNascimento.Year;
            if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
            {
                idade = idade - 1;
            }
            return idade;
        }
    }

}
