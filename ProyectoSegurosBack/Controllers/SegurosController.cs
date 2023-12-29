using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoSegurosBack.Models;
using ProyectoSegurosBack.services;
using ProyectoSegurosBack.viewmodels;

namespace ProyectoSegurosBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegurosController : ControllerBase
    {
        public ISeguros seguro;

        public SegurosController(ISeguros _seguros)
        {
            this.seguro = _seguros;
        }
        [HttpGet("ObtenerSeguros")]
        public ActionResult ObtenerSeguros()
        {
            return new JsonResult(seguro.ObtenerSeguros());
        }
        [HttpPost("setSeguros")]
        public bool setSeguro(SegurosVM seguros)
        {
            return seguro.setSeguros(seguros);
        }
        [HttpPost("putSeguros")]
        public bool putSeguros(SegurosVM seguros)
        {
            return seguro.putSeguros(seguros);
        }
        [HttpPost("deletSeguro")]
        public bool deleteSeguro(int id)
        {
            return seguro.deleteSeguro(id);
        }
       

        [HttpPost("GetAllPolizas")]
        public IActionResult GetAllPolizas(string? cedula, string? Codigo)
        {
            if (cedula == null && Codigo==null)
            {
                var result= seguro.GetAllPolizas(cedula, Codigo);
                return new JsonResult(result);
            }
            else if (cedula != null)
            {
                var resul = seguro.ObtenerSegurosByCedula(cedula);
                return new JsonResult(resul);
            }
            else
            {
                var result = seguro.ObtenerSegurosByCod(Codigo);
                return new JsonResult(result);
            }

        }
        [HttpGet("ObtenerPolizasByCed")]
        public ActionResult ObtenerPolizasByCed(string cedula)
        {
            return new JsonResult(seguro.ObtenerSegurosByCedula(cedula));
        }
        [HttpGet("ObtenerPolizasCod")]
        public ActionResult ObtenerPolizasByCod(string codigo)
        {
            return new JsonResult(seguro.ObtenerSegurosByCod(codigo));
        }
        [HttpPost("SetPolizas")]
        public ActionResult SetPolizas(SetPolizaVM poliza)
        {
            return new JsonResult(seguro.SetPoliza(poliza));
        }
        [HttpGet("ObtenerPolizasId")]
        public ActionResult ObtenerPolizasByid(int id)
        {
            return new JsonResult(seguro.ObtenerSegurosById(id));
        }


    }
}
