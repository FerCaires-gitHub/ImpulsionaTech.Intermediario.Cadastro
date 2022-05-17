using AutoMapper;
using ImpulsionaTech.Intermediario.Cadastro.Application.Queries.TiposConta;
using ImpulsionaTech.Intermediario.Cadastro.Application.Responses.TiposConta;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Handlers.TiposConta
{
    public class GetTiposContaHandler : IRequestHandler<GetTiposContaQuery, IEnumerable<GetTipoContaResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTiposContaHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetTipoContaResponse>> Handle(GetTiposContaQuery request, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.TiposConta.ListAsync(null);
            return response.Select(x => _mapper.Map<GetTipoContaResponse>(x));
        }
    }
}
