using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DataAccess;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        [HttpGet("Sum/{a}/{b}")]
        public IActionResult SumApi(int a,int b)
        {
            TestMath mm=new TestMath();
            int result=mm.Sum(a, b);
            return Ok(result);
        }
    }
}
