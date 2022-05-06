using ImpulsionaTech.Intermediario.Cadastro.Domain.Dtos.Cliente;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces
{
    public interface IClienteService : IServiceBase<ClienteRequest,ClienteResponse, Cliente>
    {
        public Task<ClienteResponse> UpdateAsync(UpdateClienteRequest entity);
    }
}
