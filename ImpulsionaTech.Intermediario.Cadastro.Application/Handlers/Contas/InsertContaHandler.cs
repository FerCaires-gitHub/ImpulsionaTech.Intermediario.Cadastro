using AutoMapper;
using ImpulsionaTech.Intermediario.Cadastro.Application.Commands.Contas;
using ImpulsionaTech.Intermediario.Cadastro.Application.Responses.Contas;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Handlers.Contas
{
    public class InsertContaHandler : IRequestHandler<InsertContaCommand, InsertContaResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InsertContaHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<InsertContaResponse> Handle(InsertContaCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Conta>(request);
            await _unitOfWork.Contas.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<InsertContaResponse>(model);
        }
    }
}
