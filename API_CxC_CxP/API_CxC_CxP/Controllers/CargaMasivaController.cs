using API_CxC_CxP.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_CxC_CxP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargaMasivaController : ControllerBase
    {
        private AnalisisFinanzasContext context = new AnalisisFinanzasContext();

        // GET: api/<CargaMasivaController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<CargaMasivaController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CargaMasivaController>
        [HttpPost]
        public ActionResult Post([FromBody] Documento doc)
        {
            try
            {
                context.Documentos.Add(doc);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //// PUT api/<CargaMasivaController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CargaMasivaController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
