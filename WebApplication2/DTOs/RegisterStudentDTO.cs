namespace WebApplication2.DTOs
{
    public class RegisterStudentDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int RegisterCourseId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int BranchId { get; set; }
    }
}
