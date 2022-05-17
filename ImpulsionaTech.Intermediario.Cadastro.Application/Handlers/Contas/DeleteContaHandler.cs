using AutoMapper;
using ImpulsionaTech.Intermediario.Cadastro.Application.Commands.Contas;
using ImpulsionaTech.Intermediario.Cadastro.Application.Queries.Contas;
using ImpulsionaTech.Intermediario.Cadastro.Application.Responses.Contas;
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
    public class DeleteContaHandler : IRequestHandler<DeleteContaCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<DeleteContaHandler> _logger;

        public DeleteContaHandler(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator, ILogger<DeleteContaHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }
        public async Task<bool> Handle(DeleteContaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Util.ValidaRequest(request);
                var model = await _mediator.Send(new GetContaByIdQuery { Id = request.Id });
                VerificaSaldoConta(model);
                var entity = _mapper.Map<Conta>(model);
                await _unitOfWork.Contas.DeleteAsync(entity);
                await _unitOfWork.SaveChangesAsync();

            }
            catch(CustomException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao deletar conta de id:{ request.Id}. Erro:{ex.Message}");
                throw new CustomException(500, $"Erro ao atualizar conta de id:{request.Id}, favor verificar a log de sistema");
            }
            return true;
        }

        private void VerificaSaldoConta(GetContaResponse model)
        {
            if (model.Saldo > 0)
                throw new CustomException(400, "Conta apresenta saldo maior que zero. Favor efetuar retirada antes de fechar");
        }
    }
}
