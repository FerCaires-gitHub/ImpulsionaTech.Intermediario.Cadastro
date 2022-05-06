using ImpulsionaTech.Intermediario.Cadastro.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces
{
    public interface IAsyncRepository<T> where T:BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);

        Task<T> GetById(int id);

        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> expression);
    }
}
