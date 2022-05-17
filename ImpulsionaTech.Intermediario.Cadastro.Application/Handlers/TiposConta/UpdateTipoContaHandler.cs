using ImpulsionaTech.Intermediario.Cadastro.Application.Commands.TiposConta;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Handlers.TiposConta
{
    public class UpdateTipoContaHandler : IRequestHandler<UpdateTipoContaCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateTipoContaHandler> _logger;

        public UpdateTipoContaHandler(IUnitOfWork unitOfWork, ILogger<UpdateTipoContaHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<bool> Handle(UpdateTipoContaCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.Id == 0)
                throw new CustomException(400, "Request inválido");

 
            try
            {
                var model = await _unitOfWork.TiposConta.GetById(request.Id);
                if (model == null)
                    throw new CustomException(404, $"Tipo de conta com id:{request.Id} não encontrado");
                model.Update(request.Descricao);
                await _unitOfWork.TiposConta.UpdateAsync(model);
                await _unitOfWork.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao atualizar TipoConta de id:{request.Id}. Erro:{ex.Message}");
                throw new CustomException(500, $"Erro ao atualizar TipoConta de id:{request.Id}. Favor verificar as logs");
            }
            return true;
        }
    }
}
