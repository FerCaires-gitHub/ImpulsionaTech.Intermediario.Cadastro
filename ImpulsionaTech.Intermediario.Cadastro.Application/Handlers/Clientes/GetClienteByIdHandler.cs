using AutoMapper;
using ImpulsionaTech.Intermediario.Cadastro.Application.Queries.Clientes;
using ImpulsionaTech.Intermediario.Cadastro.Application.Responses.Clientes;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Handlers.Clientes
{
    public class GetClienteByIdHandler : IRequestHandler<GetClienteByIdQuery, GetClienteResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetClienteByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetClienteResponse> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.Clientes.GetById(request.Id);
            return _mapper.Map<GetClienteResponse>(response);
        }
    }
}
