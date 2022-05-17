using ImpulsionaTech.Intermediario.Cadastro.Domain.Base;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Domain.Model
{
    public class Conta : BaseEntity
    {
        public int ClienteId { get; set; }
        public int TipoContaId { get; set; }
        public decimal Saldo { get; set; }

        public Conta()
        {
            this.Saldo = 0;
        }

        public void  Inativar()
        {
            this.Status = Shared.Enums.Status.Inativo;
        }

        public void Update(int tipoContaId)
        {
            if (tipoContaId == 0)
                throw new CustomException(400, "TipoContaId não informado");
            this.TipoContaId = tipoContaId;
        }

        public bool IsSaldoPositivo()
        {
            return this.Saldo > 0;
        }

        public bool SaldoNegativo(decimal valor)
        {
            return this.Saldo - valor < 0;
        }
        public bool IsAtiva()
        {
            return this.Status == Shared.Enums.Status.Ativo;
        }
    }
}
