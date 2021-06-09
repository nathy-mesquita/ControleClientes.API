using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ControleClientes.API.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            CriadoEm = DateTime.Now;
            Ativo = true;
            //Id = Guid.NewGuid();
        }

        public int Id { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public bool Ativo { get; private set; }
        public void Desativar() => Ativo = false;
    }
}
