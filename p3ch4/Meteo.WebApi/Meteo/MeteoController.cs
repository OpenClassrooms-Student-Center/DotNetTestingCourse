using System;
using Microsoft.AspNetCore.Mvc;

namespace Meteo.WebApi.Meteo
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeteoController : ControllerBase
    {
        private readonly MeteoRepository _meteoRepository;

        public MeteoController(MeteoRepository meteoRepository)
        {
            _meteoRepository = meteoRepository;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            var resultat = _meteoRepository.QuelTempsFaitIl(DateTime.Now);
            return Ok(resultat);
        }
    }
}
