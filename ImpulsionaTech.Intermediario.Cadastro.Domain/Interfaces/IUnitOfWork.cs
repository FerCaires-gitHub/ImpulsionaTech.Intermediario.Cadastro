using ImpulsionaTech.Intermediario.Cadastro.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces
{
    public interface IUnitOfWork<T> where T:BaseEntity
    {

        Task SaveChangesAsync();
        IAsyncRepository<T> GetAsyncRepository();
    }
}
