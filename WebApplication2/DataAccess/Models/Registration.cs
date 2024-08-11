using System.ComponentModel.DataAnnotations;
using WebApplication2.Controllers;

namespace WebApplication2.DataAccess.Models
{
    public class RegistrationModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public StudentModel Student { get; set; }
        public CourceModel CourceModel { get; set; } 
        public int CourceId { get; set; }
        public DateTime RegistrationDate { get; set; } 
        public SemesterModel SemesterModel  { get; set; }
        public int SemesterId  { get; set; }
    }
}
