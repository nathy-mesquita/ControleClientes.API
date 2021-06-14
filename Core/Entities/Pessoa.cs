using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ControleClientes.API.Core.Entities
{
    public class Pessoa : BaseEntity
    {
        private int idade;

        public Pessoa(string nome, string sobrenome, string cpf, DateTime dataNascimento, char genero) : base()
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
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public char Genero { get; private set; }
        public IEnumerable<Endereco> Enderecos { get; set; }
        public int Idade
        {
            get 
            {
                idade = DateTime.Now.Year - DataNascimento.Year;
                if (DateTime.Now.DayOfYear < DataNascimento.DayOfYear)
                {
                    idade = idade - 1;
                }
                return idade;
            }
            private set { idade = value; }
        }


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
