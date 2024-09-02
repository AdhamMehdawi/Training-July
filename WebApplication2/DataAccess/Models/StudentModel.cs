using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DataAccess.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } 
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        
        public List<RegistrationModel> RegistredCourses { get; set; }

    }
}
