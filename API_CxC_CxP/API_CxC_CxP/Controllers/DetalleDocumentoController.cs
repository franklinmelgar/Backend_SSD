using API_CxC_CxP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API_CxC_CxP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleDocumentoController : ControllerBase
    {
        private AnalisisFinanzasContext context = new AnalisisFinanzasContext();

        // GET: api/<DetalleDocumentosController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.DetalleDocumentos.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<DocumentosController>/5
        [HttpGet("{id}", Name = "GetDetalleDocumentos")]
        public ActionResult Get(string id)
        {
            try
            {
                var detalleDocumentoPorNumero = context.DetalleDocumentos.Where(t => t.NumeroDocumento.Equals(id)).FirstOrDefault();           
                return Ok(detalleDocumentoPorNumero);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/<DetalleDocumentosController>
        [HttpPost]
        public ActionResult Post([FromBody] DetalleDocumento detalleDocumento)
        {
            try
            {
                context.DetalleDocumentos.Add(detalleDocumento);
                context.SaveChanges();
                return CreatedAtRoute("GetDetalleDocumentos", new { id = detalleDocumento.NumeroDocumento}, detalleDocumento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT   DetalleDocumentoController
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] DetalleDocumento detalleDocumento)
        {
            try
            {
                if (detalleDocumento.NumeroDocumento.Equals(id))
                {
                    context.Entry(detalleDocumento).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetDocumentos", new { id = detalleDocumento.NumeroDocumento }, detalleDocumento);

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


        // DELETE: DetalleDocumentoController/Delete/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var detalleDocumento = context.DetalleDocumentos.Where(t => t.NumeroDocumento.Equals(id)).FirstOrDefault();
                if (detalleDocumento != null)
                {
                    context.DetalleDocumentos.Remove(detalleDocumento);
                    context.SaveChanges();
                    return Ok(id);
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
    }
}
