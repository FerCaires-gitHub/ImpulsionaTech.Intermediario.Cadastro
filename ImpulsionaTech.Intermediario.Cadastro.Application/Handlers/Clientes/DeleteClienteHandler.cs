using ImpulsionaTech.Intermediario.Cadastro.Application.Commands.Clientes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Handlers.Clientes
{
    public class DeleteClienteHandler : IRequestHandler<DeleteClienteCommand, bool>
    {
        public Task<bool> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
