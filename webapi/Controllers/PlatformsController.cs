using Microsoft.AspNetCore.Mvc;
using webapi.Interfaces;
using webapi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {

        private readonly IPlatformsService _service;

        public PlatformsController(IPlatformsService service)
        {
            _service = service;
        }

        // GET: api/<PlatformsController>
        [HttpGet]
        public async Task<ActionResult> GetAllPlatforms()
        {
            var pfs = await _service.GetAllPlatforms();
            return Ok(pfs);
        }

        // GET api/<PlatformsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPlatformById(int id)
        {
            var pf = await _service.GetPlatformById(id);
            if(pf == null)
            {
                return NotFound();
            }
            return Ok(pf);
        }

        // POST api/<PlatformsController>
        [HttpPost]
        public async Task<ActionResult> AddNew(Platform pf)
        {
            await _service.AddPlatform(pf);
            return NoContent();
        }

        // PUT api/<PlatformsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Platform pf, int id) 
        {
            var currentPf = await _service.GetPlatformById(id);
            if(currentPf == null)
            {
                return NotFound();
            }
            currentPf.Id = id;
            await _service.UpdatePlatform(pf, id);
            return NoContent();
        }

        // DELETE api/<PlatformsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var currentPf = await _service.GetPlatformById(id);
            if (currentPf == null)
            {
                return NotFound();
            }
            currentPf.Id = id;
            await _service.DeletePlatform(id);
            return NoContent();
        }
    }
}
