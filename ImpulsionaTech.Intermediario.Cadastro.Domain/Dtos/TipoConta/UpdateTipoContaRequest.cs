using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Domain.Dtos.TipoConta
{
    public class UpdateTipoContaRequest
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
