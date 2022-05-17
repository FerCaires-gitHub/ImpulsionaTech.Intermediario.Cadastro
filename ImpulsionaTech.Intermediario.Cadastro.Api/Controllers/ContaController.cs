using ImpulsionaTech.Intermediario.Cadastro.Application.Commands.Contas;
using ImpulsionaTech.Intermediario.Cadastro.Application.Queries.Contas;
using ImpulsionaTech.Intermediario.Cadastro.Application.Responses.Contas;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImpulsionaTech.Intermediario.Cadastro.Api.Controllers
{
    [Route("v1/contas")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<ContaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetContaResponse>>> Get()
        {
            try
            {
                var response = await _mediator.Send(new GetContasQuery  {});
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

        // GET api/<ContaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetContaResponse>> GetById(int id)
        {
            try
            {
                var response = await _mediator.Send(new GetContaByIdQuery { Id = id });
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

        // POST api/<ContaController>
        [HttpPost]
        public async Task<ActionResult<InsertContaResponse>> Post([FromBody] InsertContaCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return StatusCode(201,response);
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

        // PUT api/<ContaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] int tipoContaId)
        {
            try
            {
                var response = await _mediator.Send(new UpdateContaCommand { Id = id, TipoContaId = tipoContaId });
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

        [HttpPut("{id}/inativate")]
        public async Task<ActionResult> Inativate(int id)
        {
            try
            {
                var response = await _mediator.Send(new InativateContaCommand { Id = id});
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

        // DELETE api/<ContaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _mediator.Send(new DeleteContaCommand { Id = id});
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
