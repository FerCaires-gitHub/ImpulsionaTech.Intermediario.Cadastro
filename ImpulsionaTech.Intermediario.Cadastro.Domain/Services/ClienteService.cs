using AutoMapper;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Dtos.Cliente;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Domain.Services
{
    public class ClienteService : ServiceBase<ClienteRequest, ClienteResponse, Cliente>, IClienteService
    {
        private readonly IMapper _mapper;

        public ClienteService(IMapper mapper, IUnitOfWork<Cliente> unitOfWork) 
            : base(mapper, unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<ClienteResponse> UpdateAsync(UpdateClienteRequest request)
        {
            var entity = await base.GetByIdAsync(request.Id);
            var model = _mapper.Map<Cliente>(entity);
            model.Update(request.Nome);
            var response = await base.UpdateAsync(model);
            return response;
            
        }
    }
}
