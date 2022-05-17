using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Commands.Contas
{
    public class InativateContaCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
