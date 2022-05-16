using ImpulsionaTech.Intermediario.Cadastro.Domain.Base;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Model;
using ImpulsionaTech.Intermediario.Cadastro.Infrastructure.Data.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFContext _context;
        private readonly IAsyncRepository<Cliente> _clienteRepository;
        private readonly IAsyncRepository<TipoConta> _tipoContaRepository;
        private readonly IAsyncRepository<Conta> _contaRepository;

        public IAsyncRepository<TipoConta> TiposConta { get { return _tipoContaRepository; } }
        public IAsyncRepository<Cliente> Clientes { get { return _clienteRepository; }}
        public IAsyncRepository<Conta> Contas { get { return _contaRepository; } }

        public UnitOfWork(EFContext context, IAsyncRepository<Cliente> clienteRepository, 
            IAsyncRepository<TipoConta> tipoContaRepository, IAsyncRepository<Conta> contaRepository)
        {
            _context = context;
            _clienteRepository = clienteRepository;
            _tipoContaRepository = tipoContaRepository;
            _contaRepository = contaRepository;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
