using AutoMapper;
using ImpulsionaTech.Intermediario.Cadastro.Application.Queries.Clientes;
using ImpulsionaTech.Intermediario.Cadastro.Application.Responses.Clientes;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Handlers.Clientes
{
    public class GetClientesHandler : IRequestHandler<GetClientesQuery, IEnumerable<GetClienteResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetClientesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetClienteResponse>> Handle(GetClientesQuery request, CancellationToken cancellationToken)
        {
            var result =  await _unitOfWork.Clientes.ListAsync(null);
            return result.Select(x => _mapper.Map<GetClienteResponse>(x));
        }
    }
}
