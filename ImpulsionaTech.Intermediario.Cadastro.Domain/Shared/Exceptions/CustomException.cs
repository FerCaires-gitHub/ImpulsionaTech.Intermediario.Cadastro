using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Exceptions
{
    public class CustomException : Exception
    {
        public int StatusCode { get; set; }
        public CustomException(int statusCode, string message)
            :base(message)
        {
            this.StatusCode = statusCode;
        }
        
    }
}
