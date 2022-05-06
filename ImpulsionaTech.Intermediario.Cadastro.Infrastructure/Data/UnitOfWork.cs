using ImpulsionaTech.Intermediario.Cadastro.Domain.Base;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using ImpulsionaTech.Intermediario.Cadastro.Infrastructure.Data.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Infrastructure.Data
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : BaseEntity
    {
        private readonly EFContext _context;
        private AsyncRepository<T> _repository;

        public UnitOfWork(EFContext context)
        {
            _context = context;
        }

        public IAsyncRepository<T> GetAsyncRepository()
        {
            _repository = _repository ?? new AsyncRepository<T>(_context);
            return _repository;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
