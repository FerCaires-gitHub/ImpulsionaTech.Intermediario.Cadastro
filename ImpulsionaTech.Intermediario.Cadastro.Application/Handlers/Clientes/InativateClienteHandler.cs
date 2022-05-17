using AutoMapper;
using ImpulsionaTech.Intermediario.Cadastro.Application.Commands.Clientes;
using ImpulsionaTech.Intermediario.Cadastro.Application.Queries.Clientes;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Base;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Model;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Exceptions;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Utils;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Handlers.Clientes
{
    public class InativateClienteHandler : IRequestHandler<InativateClienteCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<InativateClienteHandler> _logger;

        public InativateClienteHandler(IUnitOfWork unitOfWork, IMediator mediator, IMapper mapper, ILogger<InativateClienteHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(InativateClienteCommand request, CancellationToken cancellationToken)
        {
            Util.ValidaRequest(request);
            try
            {
                var model = await _mediator.Send(new GetClienteByIdQuery { Id = request.Id });
                var entity = _mapper.Map<Cliente>(model);
                entity.Inativar();
                await _unitOfWork.Clientes.UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao inativar registro de id:{ request.Id}. Erro:{ex.Message}");
                throw new CustomException(500, $"Erro ao inativar registro de id:{request.Id}, favor verificar a log de sistema");
            }

            return true;

        }
    }
}
