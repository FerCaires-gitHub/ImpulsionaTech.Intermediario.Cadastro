using AutoMapper;
using ImpulsionaTech.Intermediario.Cadastro.Application.Queries.Contas;
using ImpulsionaTech.Intermediario.Cadastro.Application.Responses.Contas;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Handlers.Contas
{
    public class GetContaByClienteIdHandler : IRequestHandler<GetContaByClienteIdQuery, IEnumerable<GetContaResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetContaByClienteIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetContaResponse>> Handle(GetContaByClienteIdQuery request, CancellationToken cancellationToken)
        {
            Util.ValidaRequest(request);
            var response = await _unitOfWork.Contas.ListAsync(x => x.ClienteId == request.ClienteId);
            return response.Select(x => _mapper.Map<GetContaResponse>(x));
        }
    }
}
