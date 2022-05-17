using ImpulsionaTech.Intermediario.Cadastro.Domain.Base;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Domain.Model
{
    public class Cliente : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF informado não é válido")]
        public string CPF { get; set; }

        public void Update(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new CustomException(400, "Nome nulo ou vazio");
            this.Nome = nome;

        }

        public void Inativar()
        {
            this.Status = Shared.Enums.Status.Inativo;
        }
    }
}
