using AutoMapper;
using ImpulsionaTech.Intermediario.Cadastro.Application.Queries.TiposConta;
using ImpulsionaTech.Intermediario.Cadastro.Application.Responses.TiposConta;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Handlers.TiposConta
{
    public class GetTipoContaByIdHandler : IRequestHandler<GetTipoContaByIdQuery, GetTipoContaResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTipoContaByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetTipoContaResponse> Handle(GetTipoContaByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.TiposConta.GetById(request.Id);
            return _mapper.Map<GetTipoContaResponse>(response);
        }
    }
}
