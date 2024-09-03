using Microsoft.AspNetCore.Identity;
using System;

namespace WebApplication2.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime? LastLogin { get; set; }


        public void UpdateLastLogin()
        {
            LastLogin = DateTime.UtcNow;
        }
    }
}
