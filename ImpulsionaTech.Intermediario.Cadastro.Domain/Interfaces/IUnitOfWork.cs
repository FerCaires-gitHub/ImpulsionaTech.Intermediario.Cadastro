using ImpulsionaTech.Intermediario.Cadastro.Domain.Base;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IAsyncRepository<Cliente> Clientes { get; }
        public IAsyncRepository<TipoConta> TiposConta { get; }
        public IAsyncRepository<Conta> Contas { get; }
        Task SaveChangesAsync();
    }
}
