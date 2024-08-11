using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DataAccess;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupsController : ControllerBase
    {
        private MyDatabase _database;
        public LookupsController(MyDatabase database)
        {
            _database= database;
        }

        [HttpGet("GetSections")]
        public IActionResult GetSections()
        {
            return Ok(_database.Section.ToList());
        }
    }
}
