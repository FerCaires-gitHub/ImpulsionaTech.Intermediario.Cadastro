using ImpulsionaTech.Intermediario.Cadastro.Application.Responses.TiposConta;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Queries.TiposConta
{
    public class GetTipoContaByIdQuery:IRequest<GetTipoContaResponse>
    {
        public int Id { get; set; }
    }
}
