using ImpulsionaTech.Intermediario.Cadastro.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces
{

    public interface IServiceBase<TSource, TDestination, T> where TSource : class
                                                    where TDestination : class
                                                    where T : BaseEntity
    {
        Task<TDestination> InsertAsync(TSource entity);
        Task<TDestination> UpdateAsync(T entity);
        Task<TDestination> GetByIdAsync(int id);
        Task DeletetAsync(int id);
        Task<IEnumerable<TDestination>> ListAsync(Expression<Func<TSource, bool>> expression);


    }

}
