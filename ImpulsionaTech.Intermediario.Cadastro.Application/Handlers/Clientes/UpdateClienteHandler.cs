using ImpulsionaTech.Intermediario.Cadastro.Application.Commands.Clientes;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Handlers.Clientes
{
    public class UpdateClienteHandler : IRequestHandler<UpdateClienteCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateClienteHandler> _logger;

        public UpdateClienteHandler(IUnitOfWork unitOfWork, ILogger<UpdateClienteHandler> logger )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<bool> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.Id == 0)
                throw new CustomException(400, "Request inválida");
            var model = await _unitOfWork.Clientes.GetById(request.Id);
            if (model == null)
                throw new CustomException(404, $"Cliente de id:{request.Id} não encontrado");
            model.Update(request.Nome);

            try
            {
                await _unitOfWork.Clientes.UpdateAsync(model);
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
