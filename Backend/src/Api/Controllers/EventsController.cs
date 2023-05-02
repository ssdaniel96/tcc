using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        /// <summary>
        /// Salvar a captura de um evento
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Capture()
        {
            return Ok();
        }


        /// <summary>
        /// Recuperar toda lista de eventos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}
