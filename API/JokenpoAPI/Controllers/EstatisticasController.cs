using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Modelos;
using MassTransit;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JokenpoAPI.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstatisticasController : ControllerBase
    {
        private IJokenpoService JokenpoService;
        public EstatisticasController(IJokenpoService jokenpoService, IEmailService emailService)
        {
            JokenpoService = jokenpoService;
        }

        [HttpGet("{id}")]
        public ActionResult<EstatisticasUsuario> Get(string id)
        {
            return this.JokenpoService.ConsultaEstatisticaUsuario(id);
        }

        [HttpGet]
        public ActionResult<IEnumerable<EstatisticasUsuario>> GetRanking()
        {
            return this.JokenpoService.ConsultaRanking(5).ToList();
        }

    }
}
