using AutoMapper;
using ImpulsionaTech.Intermediario.Cadastro.Application.Commands.Contas;
using ImpulsionaTech.Intermediario.Cadastro.Application.Queries.Contas;
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

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Handlers.Contas
{
    public class InativateContaHandler : IRequestHandler<InativateContaCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<InativateContaHandler> _logger;

        public InativateContaHandler(IUnitOfWork unitOfWork, IMediator mediator, IMapper mapper, ILogger<InativateContaHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(InativateContaCommand request, CancellationToken cancellationToken)
        {
            Util.ValidaRequest(request);
            try
            {
                var model = _mediator.Send(new GetContaByIdQuery { Id = request.Id });
                var entity = _mapper.Map<Conta>(model);
                VerificaSaldoEAtiva(entity);
                entity.Inativar();
                await _unitOfWork.Contas.UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();

            }
            catch(CustomException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao inativar conta de id:{ request.Id}. Erro:{ex.Message}");
                throw new CustomException(500, $"Erro ao conta registro de id:{request.Id}, favor verificar a log de sistema");
            }
            return true;
        }

        private void VerificaSaldoEAtiva(Conta entity)
        {
            if (entity.IsAtiva())
                throw new CustomException(400, $"Conta de id:{entity.Id} já encerrada");
            if (entity.IsSaldoPositivo())
                throw new CustomException(400, $"Conta de id:{entity.Id} com saldo positivo. Favor providenciar retirada antes de encerrá-la");

        }
    }
}
