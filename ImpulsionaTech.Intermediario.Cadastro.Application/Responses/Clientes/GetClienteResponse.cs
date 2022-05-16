using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Responses.Clientes
{
    public class GetClienteResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string CPF { get; set; }
    }
}
