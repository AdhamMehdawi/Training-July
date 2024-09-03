using Microsoft.AspNetCore.Identity;

namespace WebApplication2.DataAccess.Models
{
    public class AppUser : IdentityUser 
    {
        //public override long Id { get; set; }
        public string FullName { get; set; }
    }
}
