﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Intermediario.Cadastro.Application.Commands.Clientes
{
    public class DeleteClienteCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
