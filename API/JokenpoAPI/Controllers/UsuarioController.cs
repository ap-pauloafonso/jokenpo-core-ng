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
    public class UsuarioController : ControllerBase
    {
        private IJokenpoService JokenpoService;
        public UsuarioController(IJokenpoService jokenpoService)
        {
            JokenpoService = jokenpoService;
        }

        [HttpPost("Login")]
        public ActionResult<Object> PostLogin(LoginDto dto)
        {
            try
            {
                return Ok(this.JokenpoService.login(dto.user, dto.senha));

            }
            catch (JokenpoBusinessException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult<Object> Post([FromBody] CriarUsuarioDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    return Ok(this.JokenpoService.CriarUsuario(dto));
                }
                catch (JokenpoBusinessException ex)
                {
                    return BadRequest(new { mensagem = ex.Message });
                }

            }
        }
    }
}
