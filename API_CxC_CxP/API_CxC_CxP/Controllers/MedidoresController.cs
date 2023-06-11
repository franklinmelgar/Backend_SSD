using API_CxC_CxP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_CxC_CxP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedidoresController : ControllerBase
    {
        private AnalisisFinanzasContext context = new AnalisisFinanzasContext();

        // GET: api/<MedidoresController>
        [HttpGet("{fechaInicial}, {fechaFinal}, {medidor}")]
        public ActionResult Get(DateTime fechaInicial, DateTime fechaFinal, string medidor)
        {
            try
            {
                if (medidor.Equals("TotalCompras"))
                {
                    return Ok(context.Documentos.Where(d => d.CodigoTipoDocumento.Equals(1) && d.FechaDocumento >= fechaInicial && d.FechaDocumento <= fechaFinal && d.EstadoDocumento.Equals("Pendiente")).Sum(c => c.MontoTotal));
                }
                else if(medidor.Equals("TotalVencido"))
                {
                    return Ok(context.Documentos.Where(d => d.CodigoTipoDocumento.Equals(1) && d.FechaVencimiento <= fechaFinal && d.EstadoDocumento.Equals("Pendiente")).Sum(c => c.MontoTotal));
                }
                else if (medidor.Equals("TotalPorVencer"))
                {
                    return Ok(context.Documentos.Where(d => d.CodigoTipoDocumento.Equals(1) && d.FechaVencimiento > fechaFinal && d.EstadoDocumento.Equals("Pendiente")).Sum(c => c.MontoTotal));
                }
                else if (medidor.Equals("graficoComprasMensuales")) {
                    var AnioActual = DateTime.Now.Year;
                    return Ok(context.Documentos.Where(d => d.CodigoTipoDocumento.Equals(1) && d.FechaDocumento.Value.Year.Equals(AnioActual)).GroupBy(d => d.FechaDocumento.Value.Month).Select(g => new { Month = g.Key, TotalAmount = g.Sum(d => d.MontoTotal)}));
                }
                else if (medidor.Equals("graficoVentasPorCategoria"))
                {
                    return Ok(context.Set<Documento>().Include(d => d.CodigoLibretaNavigation).Include(l => l.CodigoLibretaNavigation.CodigoCategoriaNavigation).Where(d => d.CodigoTipoDocumento.Equals(1) && d.FechaDocumento >= fechaInicial && d.FechaDocumento <= fechaFinal).GroupBy(d => d.CodigoLibretaNavigation.CodigoCategoriaNavigation.DescripcionCategoria).Select(g => new {DescripcionCategoria = g.Key, TotalMonto = g.Sum(dl => dl.MontoTotal)})) ;
                }
                else if (medidor.Equals("DetalleFacturasVencidas"))
                {
                    return Ok(context.Set<Documento>().Include(d => d.CodigoLibretaNavigation).Where(d => d.CodigoTipoDocumento.Equals(1) && d.FechaVencimiento <= fechaFinal).GroupBy(d => new { d.NumeroDocumento, d.CodigoLibreta, d.CodigoLibretaNavigation.NombreLibreta, d.FechaDocumento, d.FechaVencimiento } ).Select(g => new { g.Key.NumeroDocumento, g.Key.CodigoLibreta, g.Key.NombreLibreta, g.Key.FechaDocumento, g.Key.FechaVencimiento, TotalMonto = g.Sum(dl => dl.MontoTotal) }));
                }
                else if (medidor.Equals("DetallePorVencer"))
                {
                    return Ok(context.Set<Documento>().Include(d => d.CodigoLibretaNavigation).Where(d => d.CodigoTipoDocumento.Equals(1) && d.FechaVencimiento > fechaFinal && d.EstadoDocumento.Equals("Pendiente")).GroupBy(d => new { d.NumeroDocumento, d.CodigoLibreta, d.CodigoLibretaNavigation.NombreLibreta, d.FechaDocumento, d.FechaVencimiento }).Select(g => new { g.Key.NumeroDocumento, g.Key.CodigoLibreta, g.Key.NombreLibreta, g.Key.FechaDocumento, g.Key.FechaVencimiento, TotalMonto = g.Sum(dl => dl.MontoTotal) }));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<MedidoresController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<MedidoresController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<MedidoresController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<MedidoresController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
