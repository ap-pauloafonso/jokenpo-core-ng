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
        private IEmailService emailService;
        public UsuarioController(IJokenpoService jokenpoService, IEmailService emailService)
        {
            JokenpoService = jokenpoService;
            this.emailService = emailService;
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
            LoginResponseDto usuarioCriado = null;
            if (dto == null)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    usuarioCriado = this.JokenpoService.CriarUsuario(dto);
                    this.emailService.MandarEmail(usuarioCriado.user, usuarioCriado.email);
                }
                catch (JokenpoBusinessException ex)
                {
                    return BadRequest(new { mensagem = ex.Message });
                }
                catch (Exception ex)
                {
                    //TODO: log
                }
                return Ok(usuarioCriado);

            }
        }
    }
}
