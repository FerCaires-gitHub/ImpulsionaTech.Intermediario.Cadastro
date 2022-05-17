using ImpulsionaTech.Intermediario.Cadastro.Application.Commands.Clientes;
using ImpulsionaTech.Intermediario.Cadastro.Application.Queries.Clientes;
using ImpulsionaTech.Intermediario.Cadastro.Application.Responses.Clientes;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Api.Controllers
{
    [Route("v1/clientes")]
    [ApiController]
    public class ClienteController:ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IMediator _mediator;

        public ClienteController(ILogger<ClienteController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<GetClienteResponse>> Get(int id)
        {
            try
            {
                var response = await _mediator.Send(new GetClienteByIdQuery { Id =id});
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
        public async Task<ActionResult<GetClienteResponse>> Get()
        {
            try
            {
                var response = await _mediator.Send(new GetClientesQuery { });
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
        public async Task<ActionResult<InsertClienteResponse>> Insert([FromBody] InsertClienteCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);
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
        [Route("{id}")]
        public async Task<ActionResult<bool>> Update(int id, [FromBody] string nome)
        {
            try
            {
                var response = await _mediator.Send(new UpdateClienteCommand { Id = id, Nome = nome });
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
        [Route("{id}/inativate")]
        public async Task<ActionResult<bool>> Inativate(int id)
        {
            try
            {
                var response = await _mediator.Send(new InativateClienteCommand {Id = id });
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
        [Route("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteClienteCommand { Id = id });
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
