using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DataAccess;
using WebApplication2.DataAccess.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly MyDatabase _database;
        public AccountController(UserManager<IdentityUser> userManager, MyDatabase database)
        {
            _userManager = userManager;

            _database = database;

        }


        [HttpPost("CreatUser")]
        public IActionResult creatUser(User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("register information dont seem right");
                }

                var userForEntity = new AppUser
                {
                    FullName = user.fullname,
                    Email = user.email,
                    PasswordHash = user.password,
                };

                _database.AppUser.Add(userForEntity);
                 _database.SaveChanges();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
            return Ok(user);

        }
    }

    public class User
    {
       public string email { get; set; }
       public string fullname { get; set; }
        public  string password { get; set; }

        public List<string> rools { get; set; }
    }
}
