using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoSegurosBack.services;
using ProyectoSegurosBack.viewmodels;

namespace ProyectoSegurosBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        public IPersonas persona;

        public PersonasController(IPersonas _personas)
        {
            this.persona = _personas;
        }
        [HttpGet("ObtenerPersonas")]
        public ActionResult ObtenerPersonas()
        {
            return new JsonResult(persona.ObtenerPersonas());
        }
        [HttpPost("setPersonas")]
        public bool setEmpleado(PersonasVM personas)
        {
            return persona.setPersonas(personas);
        }
        [HttpPost("putPersonas")]
        public bool putPersonas(PersonasVM personas)
        {
            return persona.putPersonas(personas);
        }
        [HttpPost("deletPersona")]
        public bool deletPersona(int id)
        {
            return persona.deletePersonas(id);
        }
        

    }
}
