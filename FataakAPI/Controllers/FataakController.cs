using FataakAPI.Models;
using FataakAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FataakAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FataakController : Controller
    {
        private readonly IFataakService fataakService;

        public FataakController(IFataakService fataakService)
        {
            this.fataakService = fataakService;
        }

        [HttpGet]
        public ActionResult<List<Fataak>> Get()
        {

            return fataakService.Get();
        }

        [HttpPost]
        public ActionResult<Fataak> Post([FromBody] Fataak ftk)
        {
            fataakService.Create(ftk);
            return CreatedAtAction(nameof(Get), new { id = ftk.Id }, ftk);
        }


        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Fataak ftk)
        {
            var existingGate = fataakService.Get(id);
            if(existingGate == null) {
                return NotFound($"Gate with id={id} Not Found");
            }
            fataakService.Update(id, ftk);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var fataak = fataakService.Get(id);
            if (fataak == null)
            {
                return NotFound($"Partner with id={id} Not Found");
            }

            fataakService.Remove(fataak.Id);
            return Ok($"Partner with id={id} deleted");
        }
    }
}
