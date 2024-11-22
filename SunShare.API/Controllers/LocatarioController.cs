using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunShare.API.Requests;
using SunShare.Database.Models;
using SunShare.Repository;
using System.Net;

namespace SunShare.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Tags("Locatários")]
    public class LocatarioController : ControllerBase
    {
        private readonly IRepository<Locatario> _locatarioRepository;

        public LocatarioController(IRepository<Locatario> locatarioRepository)
        {
            _locatarioRepository = locatarioRepository;
        }

        /// <summary>
        /// Cadastra um Locatário
        /// </summary>
        /// <param name="locatarioRequest"></param>
        /// <response code = "200"> Cadastra um Locatário</response>
        /// <response code = "400"> Solicitação Inválida</response>
        /// <response code = "500"> Erro interno do servidor</response>
        /// <response code = "503"> Serviço indisponivel</response>
        /// <returns></returns>
        [HttpPost("/postLocatario")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post(LocatarioRequest locatarioRequest)
        {
            if (locatarioRequest == null) return BadRequest();

            Locatario locatario = new(locatarioRequest.Name, locatarioRequest.Email, locatarioRequest.Cpf, locatarioRequest.PhoneNumber,
                locatarioRequest.PowerCompany, locatarioRequest.AverageUsage);
            _locatarioRepository.Add(locatario);

            return Created();
        }

        /// <summary>
        /// Retorna todos os Locatários
        /// </summary>
        /// <response code = "200"> Retorna todos os Locatários</response>
        /// <response code = "204"> Nenhum locatário encontrado</response>
        /// <response code = "500"> Erro interno do servidor</response>
        /// <response code = "503"> Serviço indisponivel</response>
        /// <returns></returns>
        [HttpGet("/getAllLocatarios")]
        [ProducesResponseType(typeof(Locatario), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            return Ok(_locatarioRepository.GetAll());
        }

        /// <summary>
        /// Retorna o Locatário com o respectivo Id
        /// </summary>
        /// <param name="id"></param>
        /// <response code = "200"> Retorna um Locatário</response>
        /// <response code = "204"> Nenhum locatário encontrado</response>
        /// <response code = "500"> Erro interno do servidor</response>
        /// <response code = "503"> Serviço indisponivel</response>
        /// <returns></returns>
        [HttpGet("/getLocatarioById")]
        [ProducesResponseType(typeof(Locatario), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetById(int id)
        {
            return Ok(_locatarioRepository.GetById(id));
        }


        /// <summary>
        /// Atualiza um Locatário
        /// </summary>
        /// <param name="locatario"></param>
        /// <response code = "200"> Atualiza um Locatário</response>
        /// <response code = "204"> Nenhum locatário encontrado</response>
        /// <response code = "500"> Erro interno do servidor</response>
        /// <response code = "503"> Serviço indisponivel</response>
        /// <returns></returns>
        [HttpPut("/updateLocatario")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Update([FromBody] Locatario locatario) 
        {
            if (locatario == null) return BadRequest();

            _locatarioRepository.Update(locatario);
            return Ok();
        }


        /// <summary>
        /// Deleta um Locatário
        /// </summary>
        /// <param name="locatario"></param>
        /// <response code = "200"> Deleta um Locatário</response>
        /// <response code = "204"> Nenhum locatário encontrado</response>
        /// <response code = "500"> Erro interno do servidor</response>
        /// <response code = "503"> Serviço indisponivel</response>
        /// <returns></returns>
        [HttpDelete("/deleteLocatario")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete([FromBody] Locatario locatario)
        {
            _locatarioRepository.Delete(locatario);
            return Ok();
        }
    }
}
