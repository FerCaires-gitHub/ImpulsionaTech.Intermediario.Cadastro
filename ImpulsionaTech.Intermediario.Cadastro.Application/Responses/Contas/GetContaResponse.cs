using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Responses.Contas
{
    public class GetContaResponse
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int TipoContaId { get; set; }
        public decimal Saldo { get; set; }
    }
}
