using AutoMapper;
using ImpulsionaTech.Intermediario.Cadastro.Application.Commands.TiposConta;
using ImpulsionaTech.Intermediario.Cadastro.Application.Responses.TiposConta;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Handlers.TiposConta
{
    public class InsertTipoContaHandler : IRequestHandler<InsertTipoContaCommand, InsertTipoContaResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InsertTipoContaHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<InsertTipoContaResponse> Handle(InsertTipoContaCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<TipoConta>(request);
            var result = await _unitOfWork.TiposConta.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<InsertTipoContaResponse>(result);
        }
    }
}
