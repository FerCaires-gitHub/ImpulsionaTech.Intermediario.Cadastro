using ImpulsionaTech.Intermediario.Cadastro.Application.Responses.Contas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Queries.Contas
{
    public class GetContaByIdQuery:IRequest<GetContaResponse>
    {
        public int Id { get; set; }
    }
}
