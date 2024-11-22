using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunShare.API.Requests;
using SunShare.Database.Models;
using SunShare.Repository;
using System.Net;

namespace SunShare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Contratos")]
    public class ContratoController : ControllerBase
    {
        private readonly IRepository<Contrato> _contratoRepository;

        public ContratoController(IRepository<Contrato> contratoRepository)
        {
            _contratoRepository = contratoRepository;
        }

        /// <summary>
        /// Cadastra um Contrato
        /// </summary>
        /// <param name="contratoRequest"></param>
        /// <response code = "200"> Cadastra um Contrato</response>
        /// <response code = "500"> Erro interno do servidor</response>
        /// <response code = "503"> Serviço indisponivel</response>
        /// <returns></returns>
        [HttpPost("/postContrato")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post(ContratoRequest contratoRequest)
        {
            if (contratoRequest == null) return BadRequest();

            Contrato contrato = new(contratoRequest.LocadorId, contratoRequest.LocatarioId, contratoRequest.Duration, contratoRequest.Price,
                contratoRequest.AmountOfEnergy, contratoRequest.TermsAndConditions);
            _contratoRepository.Add(contrato);

            return Created();
        }

        /// <summary>
        /// Retorna todos os Contratos
        /// </summary>
        /// <response code = "200"> Retorna todos os Contratos</response>
        /// <response code = "204"> Nenhum contrato encontrado</response>
        /// <response code = "500"> Erro interno do servidor</response>
        /// <response code = "503"> Serviço indisponivel</response>
        /// <returns></returns>
        [HttpGet("/getAllContratos")]
        [ProducesResponseType(typeof(Contrato), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            return Ok(_contratoRepository.GetAll());
        }

        /// <summary>
        /// Retorna o Locatário com o respectivo Id
        /// </summary>
        /// <param name="id"></param>
        /// <response code = "200"> Retorna um Contrato</response>
        /// <response code = "204"> Nenhum contrato encontrado</response>
        /// <response code = "500"> Erro interno do servidor</response>
        /// <response code = "503"> Serviço indisponivel</response>
        /// <returns></returns>
        [HttpGet("/getContratoById")]
        [ProducesResponseType(typeof(Contrato), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetById(int id)
        {
            return Ok(_contratoRepository.GetById(id));
        }

        /// <summary>
        /// Atualiza um Contrato
        /// </summary>
        /// <param name="contrato"></param>
        /// <response code = "200"> Atualiza um Contrato</response>
        /// <response code = "204"> Nenhum contrato encontrado</response>
        /// <response code = "500"> Erro interno do servidor</response>
        /// <response code = "503"> Serviço indisponivel</response>
        /// <returns></returns>
        [HttpPut("/updateContrato")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Update([FromBody] Contrato contrato)
        {
            if (contrato == null) return BadRequest();

            _contratoRepository.Update(contrato);
            return Ok();
        }


        /// <summary>
        /// Deleta um Contrato
        /// </summary>
        /// <param name="contrato"></param>
        /// <response code = "200"> Deleta um Contrato</response>
        /// <response code = "204"> Nenhum contrato encontrado</response>
        /// <response code = "500"> Erro interno do servidor</response>
        /// <response code = "503"> Serviço indisponivel</response>
        /// <returns></returns>
        [HttpDelete("/deleteContrato")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete([FromBody] Contrato contrato)
        {
            _contratoRepository.Delete(contrato);
            return Ok();
        }
    }
}
