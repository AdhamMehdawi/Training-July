using WebApplication2.Entities;

namespace WebApplication2.DataAccess.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? FilePath { get; set; }
        public byte[]? FileData { get; set; }
        public int RegistrationId { get; set; } 
        public RegisterStudentModel Registration { get; set; }

    }
}
