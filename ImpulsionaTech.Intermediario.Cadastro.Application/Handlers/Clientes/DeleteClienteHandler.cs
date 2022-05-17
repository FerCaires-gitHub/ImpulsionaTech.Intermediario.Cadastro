using AutoMapper;
using ImpulsionaTech.Intermediario.Cadastro.Application.Commands.Clientes;
using ImpulsionaTech.Intermediario.Cadastro.Application.Queries.Clientes;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Model;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Handlers.Clientes
{
    public class DeleteClienteHandler : IRequestHandler<DeleteClienteCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteClienteHandler> _logger;

        public DeleteClienteHandler(IUnitOfWork unitOfWork, IMediator mediator, IMapper mapper, ILogger<DeleteClienteHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request?.Id == 0)
                throw new CustomException(400, "Request inválida");
            try
            {
                var model = await _mediator.Send(new GetClienteByIdQuery { Id = request.Id });
                await _unitOfWork.Clientes.DeleteAsync(_mapper.Map<Cliente>(model));
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao deletar registro de id:{ request.Id}. Erro:{ex.Message}");
                throw new CustomException(500, $"Erro ao deletar registro de id:{request.Id}, favor verificar a log de sistema");
            }
            return true;

        }
    }
}
