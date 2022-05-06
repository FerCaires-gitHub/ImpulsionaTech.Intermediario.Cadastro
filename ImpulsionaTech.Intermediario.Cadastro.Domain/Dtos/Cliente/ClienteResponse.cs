using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Domain.Dtos.Cliente
{
    public class ClienteResponse : BaseResponse
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
    }
}
