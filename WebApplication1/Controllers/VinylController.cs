using Microsoft.AspNetCore.Mvc;
using WebApplication1.NewFolder;
using WebApplication1.NewFolder1;

namespace WebApplication1.Controllers

{
    [ApiController]
    [Route("api/vinyl")]
    public class VinylController : ControllerBase
    {
        private readonly IVinylRepo _repo;

        public VinylController(IVinylRepo repo)
        {
            _repo = repo;
        }

        // GET /api/vinyl
        [HttpGet]
        [Route("")]

        //public List<Vinyl> GetVinyls()
        public IActionResult GetVinyls()
        {
            List<Vinyl> vinyls = _repo.GetAll();
            return Ok(vinyls);
        }

        // GET /api/vinyl/:id
        [HttpGet("{id}")]

        //public Vinyl GetVinylByID(int id)
        public IActionResult GetVinylByID(int id)
        {
            Vinyl vinyl = _repo.GetByID(id);
            if (vinyl is null)
            {
                return NotFound("Joel, I cannot find the vinyl: " + id);
            }

            return Ok(vinyl);
        }


        [HttpPost("")]
        //public Vinyl CreateVinyl([FromBody] Vinyl vinyl)
        public IActionResult CreateVinyl([FromBody] Vinyl vinyl)
        {
            Vinyl createdVinyl = _repo.CreateVinyl(vinyl);
            return CreatedAtAction(
                nameof(GetVinylByID),
                new { id = createdVinyl.Id },
                createdVinyl);
        }

        [HttpPut("")]  // put is more popular than patch
        //public Vinyl UpdateVinyl([FromBody] Vinyl vinyl)
        public IActionResult UpdateVinyl([FromBody] Vinyl vinyl)
        {
            Vinyl updatedVinyl = _repo.UpdateVinyl(vinyl);
            return Ok(updatedVinyl);
        }

        [HttpDelete("{id}")]
        //public void DeleteVinyl(int id)
        public IActionResult DeleteVinyl(int id)
        {
            _repo.DeleteVinyl(id);
            return NoContent();

        }

    }
}
