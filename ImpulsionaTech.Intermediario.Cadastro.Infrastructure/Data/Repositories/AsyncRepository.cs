using ImpulsionaTech.Intermediario.Cadastro.Domain.Base;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Infrastructure.Data.Repositories
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T:BaseEntity
    {
        private readonly ILogger<AsyncRepository<T>> _logger;
        private readonly DbSet<T> _dbSet;
        private readonly EFContext _context;

        public AsyncRepository(EFContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        private void ValidaEntidadeNula(T entity)
        {
            if (entity == null)
                throw new CustomException(400, $"{typeof(T).Name} está nula ou não informada");
        }
        public async Task<T> AddAsync(T entity)
        {
            try
            {
                ValidaEntidadeNula(entity);
                await _dbSet.AddAsync(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw new CustomException(500, ex.InnerException.ToString());
            }
        }

        public Task DeleteAsync(T entity)
        {
            try
            {
                ValidaEntidadeNula(entity);
                _dbSet.Remove(entity);
                return Task.CompletedTask;
            }
            catch (Exception ex) 
            {
                throw new CustomException(500, ex.InnerException.ToString());
            }
            
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                if (expression == null)
                    return await _dbSet.AsNoTracking().ToListAsync();
                return await _dbSet.AsNoTracking().Where(expression).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new CustomException(500, ex.InnerException.ToString());
            }
        }

        public Task<T> UpdateAsync(T entity)
        {
            try
            {
                ValidaEntidadeNula(entity);
                _dbSet.Update(entity);
                return Task.FromResult(entity);
            }
            catch (Exception ex)
            {
                throw new CustomException(500, ex.InnerException.ToString());
            }
        }

        public async Task<T> GetById(int id)
        {
            if (id <= 0)
                throw new CustomException(400, "Id não informado");
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
