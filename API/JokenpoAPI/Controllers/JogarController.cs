using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Business.Dtos;
using Business.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace JokenpoAPI.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogarController : ControllerBase
    {

        private IJokenpoService JokenpoService;
        public JogarController(IJokenpoService jokenpoService)
        {
            JokenpoService = jokenpoService;
        }
        [HttpPost("comecar")]
        public ActionResult<Object> PostComecarPartida([FromBody] ComecarPartidaDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(this.JokenpoService.ComecarPartida(dto.user, dto.escolha));
            }
        }

        public ActionResult<Object> PostJogar([FromBody] JogarDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(this.JokenpoService.jogar(dto.partida, dto.round, dto.escolha));
            }
        }

        [HttpGet("partida/{id}")]
        public ActionResult<Object> GetInformacoesPartida(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(this.JokenpoService.ConsultaPartida(id));
            }
        }

    }
}