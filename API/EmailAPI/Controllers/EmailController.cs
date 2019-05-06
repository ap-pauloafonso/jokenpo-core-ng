using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.EmailService.Contratos;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace EmailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        IBusControl _bus;
        public EmailController(IBusControl bus)
        {
            this._bus = bus;
        }

        [HttpGet("confirmation/{user}")]
        public ActionResult Get(string user)
        {
            this._bus.Publish<IEmailConfirmado>(new IEmailConfirmado() { user = user, dataConfirmacao = DateTime.Now });
            return Ok("Email foi confirmado e será integrado no sistema");
        }

        [HttpGet("")]
        public ActionResult Gettest()
        {
            return Ok();
        }


    }
}
