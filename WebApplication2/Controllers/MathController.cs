using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DataAccess;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        private TestMath _testMath;
        public MathController(TestMath testMath)
        {
            _testMath = testMath;
        }

        [HttpGet("Sum/{a}/{b}")]
        public IActionResult SumApi(int a, int b)
        {
            int result = _testMath.Sum(a, b);
            return Ok(result);
        }

        [HttpGet("Multiply/{a}/{b}")]
        public IActionResult MultiplyApi(int a, int b)
        {
            int result = _testMath.Multiply(a, b);
            return Ok(result);
        }
    }
}
