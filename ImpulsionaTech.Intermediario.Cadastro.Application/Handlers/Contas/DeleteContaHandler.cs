using ImpulsionaTech.Intermediario.Cadastro.Application.Commands.Contas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Handlers.Contas
{
    public class DeleteContaHandler : IRequestHandler<DeleteContaCommand, bool>
    {
        public Task<bool> Handle(DeleteContaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
