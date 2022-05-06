using AutoMapper;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Dtos.TipoConta;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Domain.Services
{
    public class TipoContaService : ServiceBase<TipoContaRequest, TipoContaResponse, TipoConta>, ITipoContaService
    {
        public TipoContaService(IMapper mapper, IUnitOfWork<TipoConta> unitOfWork) :
            base(mapper, unitOfWork)
        {
        }
    }
}
