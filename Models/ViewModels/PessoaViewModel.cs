using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic; 
using ControleClientes.API.Core.Entities;

namespace ControleClientes.API.Models.ViewModels
{
    //É necessário ter uma pesquisa de pessoa por CPF.
    public class PessoaViewModel
    {
        public PessoaViewModel(int id, string nome, string sobrenome, string cpf, DateTime dataNascimento, char genero, IEnumerable<Endereco> endereco)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Genero = genero;

            this.Endereco = new List<Endereco>();
        }

        public int Id { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public bool Ativo { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public char Genero { get; private set; }
        public IEnumerable<Endereco> Endereco { get; set; }
    }
}
