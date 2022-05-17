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
    public class UpdateContaHandler : IRequestHandler<UpdateContaCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<UpdateContaHandler> _logger;

        public UpdateContaHandler(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator, ILogger<UpdateContaHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }
        public async Task<bool> Handle(UpdateContaCommand request, CancellationToken cancellationToken)
        {
            Util.ValidaRequest(request);
            try
            {
                var model = await _mediator.Send(new GetContaByIdQuery { Id = request.Id });
                var entity = _mapper.Map<Conta>(model);
                entity.Update(request.TipoContaId);
                await _unitOfWork.Contas.UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                _logger.LogError($"Erro ao atualizar registro de id:{ request.Id}. Erro:{ex.Message}");
                throw new CustomException(500, $"Erro ao atualizar registro de id:{request.Id}, favor verificar a log de sistema");
            }

            return true;
        }
    }
}
