using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Commands.Clientes
{
    public class InativateClienteCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
