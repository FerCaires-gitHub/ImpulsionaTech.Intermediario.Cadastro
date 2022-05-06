using ImpulsionaTech.Intermediario.Cadastro.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Domain.Model
{
    public class Conta : BaseEntity
    {
        public int ClienteId { get; set; }
        public int TipoContaId { get; set; }
        public double Saldo { get; set; }

        public Conta()
        {
            this.Saldo = 0;
        }
    }
}
