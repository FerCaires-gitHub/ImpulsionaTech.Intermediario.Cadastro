using AutoMapper;
using ImpulsionaTech.Intermediario.Cadastro.Application.Commands.Clientes;
using ImpulsionaTech.Intermediario.Cadastro.Application.Commands.Contas;
using ImpulsionaTech.Intermediario.Cadastro.Application.Queries.Clientes;
using ImpulsionaTech.Intermediario.Cadastro.Application.Queries.Contas;
using ImpulsionaTech.Intermediario.Cadastro.Application.Responses.Clientes;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Model;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Enums;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var entity = _mapper.Map<Cliente>(model);
                VerificaClienteAtivo(entity);
                await VerificaSaldoEDeletaContas(entity);
                await _unitOfWork.Clientes.DeleteAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (CustomException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao deletar registro de id:{ request.Id}. Erro:{ex.Message}");
                throw new CustomException(500, $"Erro ao deletar registro de id:{request.Id}, favor verificar a log de sistema");
            }
            return true;

        }

        private async Task VerificaSaldoEDeletaContas(Cliente entity)
        {
            var contas = await _mediator.Send(new GetContaByClienteIdQuery { ClienteId = entity.Id });
            if (!contas.Any())
                return;
            if (contas.Count(x => x.Saldo > 0) > 0)
                throw new CustomException(400, $"Existem contas com saldo. Favor providenciar a retirada antes de excluir o cliente");
            foreach (var item in contas)
            {
                var conta = _mapper.Map<Conta>(item);
                await _unitOfWork.Contas.DeleteAsync(conta);
            }

        }

        private void VerificaClienteAtivo(Cliente model)
        {
            if (model.Status != Status.Ativo)
                throw new CustomException(400, $"Cliente de id:{model.Id} já foi inativado");
        }
    }
}
