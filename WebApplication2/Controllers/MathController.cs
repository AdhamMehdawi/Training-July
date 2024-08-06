using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Runtime.InteropServices;
using WebApplication2.Services.Math;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        private TestMath _testmath;
        public MathController(TestMath testmath)
        {
            _testmath = testmath;
        }


        [HttpGet("Sum/{a}/{b}")]
        public IActionResult Sum([FromRoute] int a,[FromRoute] int b)
        {
            return Ok(_testmath.sum(a, b));
        }


        [HttpGet("Multiply/{a}/{b}")]
        public IActionResult Multiply(int a ,int b)
        {
            return Ok(_testmath.Multiply(a, b));
        }

        [HttpGet("Subtract/{a}/{b}")]
        public IActionResult Subtract(int a, int b)
        {
            return Ok(_testmath.Subtract(a, b));
        }


        [HttpGet("Divide/{a}/{b}")]
        public IActionResult Divide(int a, int b)
        {
            return Ok(_testmath.Divide(a, b));
        }

        [HttpGet("Modulus/{a}/{b}")]
        public IActionResult Modulus(int a, int b)
        {
            return Ok(_testmath.Modulus(a, b));
        }
    }
}
