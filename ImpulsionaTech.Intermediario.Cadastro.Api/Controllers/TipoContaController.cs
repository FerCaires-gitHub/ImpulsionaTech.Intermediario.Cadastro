using ImpulsionaTech.Intermediario.Cadastro.Domain.Dtos.TipoConta;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Api.Controllers
{
    [ApiController]
    [Route("v1/tipos_conta")]
    public class TipoContaController:ControllerBase
    {
        private readonly ITipoContaService _service;

        public TipoContaController(ITipoContaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<TipoContaResponse>> Get()
        {
            try
            {
                var response = await _service.ListAsync(null);
                return Ok(response);
            }
            catch(CustomException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
