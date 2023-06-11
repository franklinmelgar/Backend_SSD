using API_CxC_CxP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_CxC_CxP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaLibretaController : ControllerBase
    {
        private AnalisisFinanzasContext context = new AnalisisFinanzasContext();

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.CategoriaLibreta.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetCategoriaLibreta")]
        public ActionResult Get(int id)
        {
            try
            {
                var categoriaLibreta = context.CategoriaLibreta.Where(t => t.CodigoCategoria.Equals(id)).FirstOrDefault();
                return Ok(categoriaLibreta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] CategoriaLibretum categoriaLibreta)
        {
            try
            {
                context.CategoriaLibreta.Add(categoriaLibreta);
                context.SaveChanges();
                return CreatedAtRoute("GetCategoriaLibreta", new { id = categoriaLibreta.CodigoCategoria }, categoriaLibreta);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CategoriaLibretum categoriaLibreta)
        {
            try
            {
                if (categoriaLibreta.CodigoCategoria.Equals(id))
                {
                    context.Entry(categoriaLibreta).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetCategoriaLibreta", new { id = categoriaLibreta.CodigoCategoria }, categoriaLibreta);
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

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var categoriaLibreta = context.CategoriaLibreta.Where(t => t.CodigoCategoria.Equals(id)).FirstOrDefault();
                if (categoriaLibreta != null)
                {
                    context.CategoriaLibreta.Remove(categoriaLibreta);
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
