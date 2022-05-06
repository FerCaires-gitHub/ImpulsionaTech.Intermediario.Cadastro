using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Domain.Dtos.Cliente
{
    public class UpdateClienteRequest 
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string Nome { get; set; }
    }
}
