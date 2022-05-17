using ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Responses.TiposConta
{
    public class GetTipoContaResponse
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Status Status { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
