using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ControleClientes.API.Core.Entities;

namespace ControleClientes.API.Persistence
{
    public class ControleClientesDbContext : DbContext
    {
        public ControleClientesDbContext(DbContextOptions<ControleClientesDbContext> options): base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>(e => 
            {
                e.HasKey(p => p.Id);

                //Uma pessoa pode ter n endereços, um endereço vai ter apenas uma pessoa, chave estrangeira cpfPessoa e restringir a deleção de pessoa.
                e.HasMany(p => p.Enderecos)
                    .WithOne()
                    .HasForeignKey(e => e.IdPessoa)
                    .OnDelete(DeleteBehavior.Restrict);
             });

            modelBuilder.Entity<Endereco>(e => 
            {
                e.HasKey(e => e.Id);
            });


            //dotnet ef migrations add InitialMigration -o Persistence/Migrations 
        }
    }
}
