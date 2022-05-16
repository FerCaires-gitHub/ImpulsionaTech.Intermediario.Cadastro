using ImpulsionaTech.Intermediario.Cadastro.Application.Responses.Clientes;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Annotation;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Commands.Clientes
{
    public class InsertClienteCommand : IRequest<InsertClienteResponse>
    {
        [Required]
        [StringLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string Nome { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF informado não é válido")]
        [ValidaCPFAtributte]
        public string CPF { get; set; }
    }
}
