using ImpulsionaTech.Intermediario.Cadastro.Application.Responses.Contas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Commands.Contas
{
    public class InsertContaCommand : IRequest<InsertContaResponse>
    {
        public int ClienteId { get; set; }
        public int TipoContaId { get; set; }

    }
}
