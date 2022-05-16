using AutoMapper;
using ImpulsionaTech.Intermediario.Cadastro.Application.Commands.Clientes;
using ImpulsionaTech.Intermediario.Cadastro.Application.Responses.Clientes;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Handlers.Clientes
{
    public class InsertClienteHandler : IRequestHandler<InsertClienteCommand, InsertClienteResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InsertClienteHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<InsertClienteResponse> Handle(InsertClienteCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Cliente>(request);
            var result = await InsertClienteAsync(model);
            return _mapper.Map<InsertClienteResponse>(result);

        }

        private async Task<Cliente> InsertClienteAsync(Cliente model)
        {
            await _unitOfWork.Clientes.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();
            return model;
        }
    }
}
