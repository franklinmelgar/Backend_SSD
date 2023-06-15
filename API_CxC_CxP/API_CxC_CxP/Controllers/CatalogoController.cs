using API_CxC_CxP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_CxC_CxP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        private AnalisisFinanzasContext context = new AnalisisFinanzasContext();
        // GET: api/<ProveedoresController>
        [HttpGet("{tipo}")]
        public ActionResult Get(string tipo)
        {
            if (tipo.Equals("Proveedores"))
            {
                return Ok(context.LibretaDirecciones.Where(l => l.CodigoTipo.Equals(1)));
            } else if (tipo.Equals("tipoDocumentos")) { 
                return Ok(context.TipoDocumentos.ToList());
            }
            else if (tipo.Equals("terminoCredito"))
            {
                return Ok(context.TerminosCreditos.ToList());
            }else if (tipo.Equals("CuentasPorCobrar"))
            {
                return Ok(context.Set<Documento>().Include(d => d.CodigoLibretaNavigation).Where(d => d.CodigoTipoDocumento.Equals(2)).GroupBy(d => new { d.NumeroDocumento, d.CodigoLibreta, d.CodigoLibretaNavigation.NombreLibreta, d.FechaDocumento, d.FechaVencimiento }).Select(g => new { g.Key.NumeroDocumento, g.Key.CodigoLibreta, g.Key.NombreLibreta, g.Key.FechaDocumento, g.Key.FechaVencimiento, TotalMonto = g.Sum(dl => dl.MontoTotal) }));
            }else if (tipo.Equals("CuentasPorPagar"))
            {
                return Ok(context.Set<Documento>().Include(d => d.CodigoLibretaNavigation).Where(d => d.CodigoTipoDocumento.Equals(1)).GroupBy(d => new { d.NumeroDocumento, d.CodigoLibreta, d.CodigoLibretaNavigation.NombreLibreta, d.FechaDocumento, d.FechaVencimiento }).Select(g => new { g.Key.NumeroDocumento, g.Key.CodigoLibreta, g.Key.NombreLibreta, g.Key.FechaDocumento, g.Key.FechaVencimiento, TotalMonto = g.Sum(dl => dl.MontoTotal) }));
            }
            else
            {
                return Ok(context.TipoDocumentos.ToList());
            }

        }
    }
}
