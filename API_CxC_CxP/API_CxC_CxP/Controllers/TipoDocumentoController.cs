using API_CxC_CxP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_CxC_CxP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TipoDocumentoController : ControllerBase
    {
        private AnalisisFinanzasContext context = new AnalisisFinanzasContext();

        // GET: TipoDocumentoController
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var respuesta = context.TipoDocumentos.ToList();
                return Ok(respuesta);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: TipoDocumentoController
        [HttpGet("{id}", Name = "GetTipoDocumento")]
        public ActionResult Get(int id)
        {
            try
            {
                var tipoDocumento = context.TipoDocumentos.Where(t => t.CodigoTipoDocumento.Equals(id)).FirstOrDefault();
                return Ok(tipoDocumento);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: TipoDocumentoController/Create
        [HttpPost]
        public ActionResult Post([FromBody] TipoDocumento tipoDocumento)
        {
            try
            {
                context.TipoDocumentos.Add(tipoDocumento);
                context.SaveChanges();
                return CreatedAtRoute("GetTipoDocumento", new { id = tipoDocumento.CodigoTipoDocumento }, tipoDocumento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: TipoDocumentoController
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TipoDocumento tipoDocumento)
        {
            try
            {
                if (tipoDocumento.CodigoTipoDocumento.Equals(id))
                {
                    context.Entry(tipoDocumento).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetTipoDocumento", new { id = tipoDocumento.CodigoTipoDocumento }, tipoDocumento);
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

      
        // DELETE: TipoDocumentoController/Delete/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var tipoDocumento = context.TipoDocumentos.Where(t => t.CodigoTipoDocumento.Equals(id)).FirstOrDefault();
                if(tipoDocumento != null)
                {
                    context.TipoDocumentos.Remove(tipoDocumento);
                    context.SaveChanges();
                    return Ok(id);
                }else 
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
