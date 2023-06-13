using API_CxC_CxP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_CxC_CxP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private AnalisisFinanzasContext context = new AnalisisFinanzasContext();

        // GET: api/<ProductosController>
        [HttpGet]

        public ActionResult Get()
        {
            try
            {
                return Ok(context.Productos.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}", Name = "GetProductos")]
        public ActionResult Get(int id)
        {
            try
            {
                var Productos = context.Productos.Where(t => t.CodigoProducto.Equals(id)).FirstOrDefault();
                return Ok(Productos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProductosController>
        [HttpPost]
        public ActionResult Post([FromBody] Producto productos)
        {
            try
            {
                context.Productos.Add(productos);
                context.SaveChanges();
                return CreatedAtRoute("GetProductos", new { id = productos.CodigoProducto }, productos);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Producto productos)
        {
            try
            {
                if (productos.CodigoProducto.Equals(id))
                {
                    context.Entry(productos).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetProductos", new { id = productos.CodigoProducto }, productos);
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

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var Productos = context.Productos.Where(t => t.CodigoProducto.Equals(id)).FirstOrDefault();
                if (Productos != null)
                {
                    context.Productos.Remove(Productos);
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
