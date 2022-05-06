using ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Annotation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Domain.Dtos.Cliente
{
    public class ClienteRequest
    {
        [Required]
        [StringLength(50,ErrorMessage ="Máximo de 50 caracteres")]
        public string Nome { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF informado não é válido")]
        [ValidaCPFAtributte]
        public string CPF { get; set; }
    }
}
