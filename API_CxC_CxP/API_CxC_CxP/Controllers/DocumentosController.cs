using API_CxC_CxP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API_CxC_CxP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentosController : ControllerBase
    {
        private AnalisisFinanzasContext context = new AnalisisFinanzasContext();

        // GET: api/<DocumentosController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var respuesta = context.Documentos.ToList(); 
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<DocumentosController>/5
        [HttpGet("{id}", Name = "GetDocumento")]
        public ActionResult Get(string id)
        {
            try
            {
                var documento =context.Documentos.Where(f => f.NumeroDocumento.Equals(id)).FirstOrDefault();
                return Ok(documento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/<DocumentosController>
        [HttpPost]
        public ActionResult Post([FromBody] Documento documento)
        {
            try
            {
                context.Documentos.Add(documento);
                context.SaveChanges();
                return CreatedAtRoute("GetDocumento", new { id = documento.NumeroDocumento }, documento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT   DocumentosController
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Documento documento)
        {
            try
            {                
                if (documento.NumeroDocumento.Equals(id))
                {
                    context.Entry(documento).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetDocumentos", new { id = documento.NumeroDocumento }, documento);
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


        // DELETE: DocumentosController/Delete
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                var documento = context.Documentos.Where(t => t.NumeroDocumento.Equals(id)).FirstOrDefault();
                if (documento != null)
                {
                    context.Documentos.Remove(documento);
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
