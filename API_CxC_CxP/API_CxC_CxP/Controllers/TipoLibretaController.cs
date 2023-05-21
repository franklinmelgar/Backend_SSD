using API_CxC_CxP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_CxC_CxP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoLibretaController : ControllerBase
    {

        private AnalisisFinanzasContext context = new AnalisisFinanzasContext();

        // GET: api/<TipoLibretaController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.TipoLibreta.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<TipoLibretaController>/5
        [HttpGet("{id}", Name = "GetTipoLibreta")]
        public ActionResult Get(int id)
        {
            try
            {
                var tipoLibreta = context.TipoLibreta.Where(t => t.CodigoTipo.Equals(id)).FirstOrDefault();
                return Ok(tipoLibreta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<TipoLibretaController>
        [HttpPost]
        public ActionResult Post([FromBody] TipoLibretum tipoLibreta)
        {
            try
            {
                context.TipoLibreta.Add(tipoLibreta);
                context.SaveChanges();
                return CreatedAtRoute("GetTipoLibreta", new { id = tipoLibreta.CodigoTipo }, tipoLibreta);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<TipoLibretaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TipoLibretum tipoLibreta)
        {
            try
            {
                if (tipoLibreta.CodigoTipo.Equals(id))
                {
                    context.Entry(tipoLibreta).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetTipoLibreta", new { id = tipoLibreta.CodigoTipo }, tipoLibreta);
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

        // DELETE api/<TipoLibretaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var tipoLibreta = context.TipoLibreta.Where(t => t.CodigoTipo.Equals(id)).FirstOrDefault();
                if (tipoLibreta != null)
                {
                    context.TipoLibreta.Remove(tipoLibreta);
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
