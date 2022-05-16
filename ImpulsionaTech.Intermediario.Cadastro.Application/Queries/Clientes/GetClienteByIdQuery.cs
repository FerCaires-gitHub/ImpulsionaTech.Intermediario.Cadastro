using ImpulsionaTech.Intermediario.Cadastro.Application.Responses.Clientes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Queries.Clientes
{
    public class GetClienteByIdQuery: IRequest<GetClienteResponse>
    {
        public int Id { get; set; }
    }
}
