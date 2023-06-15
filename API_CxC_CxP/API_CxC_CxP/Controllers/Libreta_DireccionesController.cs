using API_CxC_CxP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_CxC_CxP.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Libreta_DireccionesController : ControllerBase
    {
        private AnalisisFinanzasContext context = new AnalisisFinanzasContext();

        // GET: api/<Libreta_DireccionesController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.LibretaDirecciones.ToList());                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<Libreta_DireccionesController>/5

        [HttpGet("{id}", Name = "GetLibretaDirecciones")]
        public ActionResult Get(int id)
        {
            try
            {
                var LibretaDirecciones = context.LibretaDirecciones.Where(t => t.CodigoLibreta.Equals(id)).FirstOrDefault();
                return Ok(LibretaDirecciones);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<Libreta_DireccionesController>
        [HttpPost]
        public ActionResult Post([FromBody] LibretaDireccione libretaDirecciones)
        {
            try
            {
                context.LibretaDirecciones.Add(libretaDirecciones);
                context.SaveChanges();
                return CreatedAtRoute("GetLibretaDirecciones", new { id = libretaDirecciones.CodigoTipo }, libretaDirecciones);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<Libreta_DireccionesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] LibretaDireccione libretaDirecciones)
        {
            try
            {
                if (libretaDirecciones.CodigoLibreta.Equals(id))
                {
                    context.Entry(libretaDirecciones).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetLibretaDirecciones", new { id = libretaDirecciones.CodigoLibreta }, libretaDirecciones);
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

        // DELETE api/<Libreta_DireccionesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var libretaDirecciones = context.LibretaDirecciones.Where(t => t.CodigoLibreta.Equals(id)).FirstOrDefault();
                if (libretaDirecciones != null)
                {
                    context.LibretaDirecciones.Remove(libretaDirecciones);
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
