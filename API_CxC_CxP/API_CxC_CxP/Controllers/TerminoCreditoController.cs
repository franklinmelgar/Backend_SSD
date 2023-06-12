using API_CxC_CxP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_CxC_CxP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class TerminoCreditoController : ControllerBase
    {
        private AnalisisFinanzasContext context = new AnalisisFinanzasContext();

        // GET: TerminoCreditoController
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.TerminosCreditos.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: TerminoCreditoController/
        [HttpGet("{id}", Name = "GetTerminoCredito")]
        public ActionResult Get(int id)
        {
            try
            {
                var terminoCredito = context.TerminosCreditos.Where(t => t.CodigoTerminoCredito.Equals(id)).FirstOrDefault();
                return Ok(terminoCredito);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST: TerminoCreditoController/
        [HttpPost]
        public ActionResult Post([FromBody] TerminosCredito terminoCredito)
        {
            try
            {
                context.TerminosCreditos.Add(terminoCredito);
                context.SaveChanges();
                return CreatedAtRoute("GetTerminoCredito", new { id = terminoCredito.CodigoTerminoCredito }, terminoCredito);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // Put: TerminoCreditoController/
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TerminosCredito terminoCredito)
        {
            try
            {
                if (terminoCredito.CodigoTerminoCredito.Equals(id))
                {
                    context.Entry(terminoCredito).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetTerminoCredito", new { id = terminoCredito.CodigoTerminoCredito }, terminoCredito);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Delete: 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var terminoCredito = context.TerminosCreditos.Where(t => t.CodigoTerminoCredito.Equals(id)).FirstOrDefault();
                if(terminoCredito != null)
                {
                    context.TerminosCreditos.Remove(terminoCredito);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
