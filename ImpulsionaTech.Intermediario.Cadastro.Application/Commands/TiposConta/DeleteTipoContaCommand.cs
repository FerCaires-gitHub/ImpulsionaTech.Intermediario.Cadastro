using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Commands.TiposConta
{
    public class DeleteTipoContaCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
