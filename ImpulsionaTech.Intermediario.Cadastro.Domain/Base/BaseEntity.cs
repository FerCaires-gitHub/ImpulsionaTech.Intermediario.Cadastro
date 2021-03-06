using ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Domain.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateTime DataCriacao { get; set; }

        public BaseEntity()
        {
            Status = Status.Ativo;
            DataCriacao = DateTime.Now;
        }
    }
}
