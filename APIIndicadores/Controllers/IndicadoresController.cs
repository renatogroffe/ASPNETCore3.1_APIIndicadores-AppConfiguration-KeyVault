using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using APIIndicadores.Models;

namespace APIIndicadores.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndicadoresController : ControllerBase
    {
        [HttpGet]
        public object Get([FromServices]IConfiguration configuration)
        {
            var relacaoIndicadores = new RelacaoIndicadores();
            new ConfigureFromConfigurationOptions<RelacaoIndicadores>(
                configuration.GetSection("Indicadores"))
                    .Configure(relacaoIndicadores);

            return relacaoIndicadores;
        }
    }
}