using ImpulsionaTech.Intermediario.Cadastro.Domain.Dtos.Cliente;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Api.Controllers
{
    [Route("v1/clientes")]
    [ApiController]
    public class ClienteController:ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteService _service;

        public ClienteController(ILogger<ClienteController> logger, IClienteService service)
        {
            _logger = logger;
            _service = service;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ClienteResponse>> Get(int id)
        {
            try
            {
                var response = await _service.GetByIdAsync(id);
                return Ok(response);
            }
            catch (CustomException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.ToString());
            }
        }

        [HttpGet]
        public async Task<ActionResult<ClienteResponse>> Get()
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
                return StatusCode(500,ex.InnerException.ToString());
            }
        }

        [HttpPost]
        public async Task<ActionResult<ClienteResponse>> Insert([FromBody] ClienteRequest request)
        {
            try
            {
                var response = await _service.InsertAsync(request);
                return Ok(response);
            }
            catch (CustomException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.ToString());
            }
        }
        [HttpPut]
        public async Task<ActionResult<ClienteResponse>> Update([FromBody] UpdateClienteRequest request)
        {
            try
            {
                var response = await _service.UpdateAsync(request);
                return Ok(response);
            }
            catch (CustomException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.ToString());
            }
        }

        [HttpDelete]
        public async Task<ActionResult<ClienteResponse>> Delete(int id)
        {
            try
            {
                await _service.DeletetAsync(id);
                return Ok();
            }
            catch (CustomException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.ToString());
            }
        }
    }
}
