using WebApplication2.Controllers;

namespace WebApplication2.DataAccess.Models
{
    public class RegistrationModel
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
