using ImpulsionaTech.Intermediario.Cadastro.Domain.Base;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Domain.Model
{
    public class TipoConta : BaseEntity
    {
        public string Descricao { get; set; }

        public void Update(string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new CustomException(400, "Descrição não pode ser nula ou vazia");
            this.Descricao = descricao;
        }
    }
}
