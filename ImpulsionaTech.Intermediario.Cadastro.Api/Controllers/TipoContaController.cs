using ImpulsionaTech.Intermediario.Cadastro.Application.Commands.TiposConta;
using ImpulsionaTech.Intermediario.Cadastro.Application.Queries.TiposConta;
using ImpulsionaTech.Intermediario.Cadastro.Application.Responses.TiposConta;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Shared.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ImpulsionaTech.Intermediario.Cadastro.Api.Controllers
{
    [ApiController]
    [Route("v1/tipos_conta")]
    public class TipoContaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TipoContaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetTipoContaResponse>> Get()
        {
            try
            {
                var response = await _mediator.Send(new GetTiposContaQuery { });
                return Ok(response);
            }
            catch (CustomException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<GetTipoContaResponse>> GetById(int id)
        {
            try
            {
                var response = await _mediator.Send(new GetTipoContaByIdQuery { Id = id });
                return Ok(response);
            }
            catch (CustomException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<InsertTipoContaResponse>> InsertTipoConta([FromBody]InsertTipoContaCommand command )
        {

            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (CustomException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<InsertTipoContaResponse>> UpdateTipoConta(int id,[FromBody] string descricao)
        {

            try
            {
                var response = await _mediator.Send(new UpdateTipoContaCommand { Id = id, Descricao = descricao });
                return Ok(response);
            }
            catch (CustomException ex)
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
