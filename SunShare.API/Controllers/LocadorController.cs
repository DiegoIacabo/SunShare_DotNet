using Microsoft.AspNetCore.Mvc;
using SunShare.API.Requests;
using SunShare.Database.Models;
using SunShare.Repository;
using System.Net;

namespace SunShare.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Tags("Locadores")]
    public class LocadorController : ControllerBase
    {
        private readonly IRepository<Locador> _locadorRepository;

        public LocadorController(IRepository<Locador> locadorRepository) {
            _locadorRepository = locadorRepository;
        }

        /// <summary>
        /// Cadastra um Locador
        /// </summary>
        /// <param name="locadorRequest"></param>
        /// <response code = "200"> Cadastra um Locador</response>
        /// <response code = "400"> Solicitação Inválida</response>
        /// <response code = "500"> Erro interno do servidor</response>
        /// <response code = "503"> Serviço indisponivel</response>
        /// <returns></returns>
        [HttpPost("/postLocador")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post(LocadorRequest locadorRequest)
        {
            if (locadorRequest == null) return BadRequest();

            Locador locador = new(locadorRequest.Name, locadorRequest.Email, locadorRequest.Cpf, locadorRequest.PhoneNumber,
                locadorRequest.PowerCompany, locadorRequest.AverageProduction, locadorRequest.AvailableEnergy);
            _locadorRepository.Add(locador);

            return Created();
        }

        /// <summary>
        /// Retorna todos os Locadores
        /// </summary>
        /// <response code = "200"> Retorna todos os Locadores</response>
        /// <response code = "204"> Nenhum locador encontrado</response>
        /// <response code = "500"> Erro interno do servidor</response>
        /// <response code = "503"> Serviço indisponivel</response>
        /// <returns></returns>
        [HttpGet("/getAllLocadores")]
        [ProducesResponseType(typeof(Locador), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            return Ok(_locadorRepository.GetAll());
        }

        /// <summary>
        /// Retorna o Locador com o respectivo Id
        /// </summary>
        /// <param name="id"></param>
        /// <response code = "200"> Retorna um Locador</response>
        /// <response code = "204"> Nenhum locador encontrado</response>
        /// <response code = "500"> Erro interno do servidor</response>
        /// <response code = "503"> Serviço indisponivel</response>
        /// <returns></returns>
        [HttpGet("/getLocadorById")]
        [ProducesResponseType(typeof(Locador), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetById(int id)
        {
            return Ok(_locadorRepository.GetById(id));
        }

        /// <summary>
        /// Atualiza um Locador
        /// </summary>
        /// <param name="locador"></param>
        /// <response code = "200"> Atualiza um Locador</response>
        /// <response code = "204"> Nenhum locador encontrado</response>
        /// <response code = "500"> Erro interno do servidor</response>
        /// <response code = "503"> Serviço indisponivel</response>
        /// <returns></returns>
        [HttpPut("/updateLocador")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Update([FromBody] Locador locador)
        {
            if (locador == null) return BadRequest();

            _locadorRepository.Update(locador);
            return Ok();
        }


        /// <summary>
        /// Deleta um Locador
        /// </summary>
        /// <param name="locador"></param>
        /// <response code = "200"> Deleta um Locador</response>
        /// <response code = "204"> Nenhum locador encontrado</response>
        /// <response code = "500"> Erro interno do servidor</response>
        /// <response code = "503"> Serviço indisponivel</response>
        /// <returns></returns>
        [HttpDelete("/deleteLocador")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete([FromBody] Locador locador)
        {
            _locadorRepository.Delete(locador);
            return Ok();
        }


    }
}
