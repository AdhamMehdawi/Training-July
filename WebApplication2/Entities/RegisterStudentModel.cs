namespace WebApplication2.Entities
{
    public class RegisterStudentModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int RegisterCourseId { get; set; }
        public DateTime RegistrationDate { get; set; }

        public StudentModel Student { get; set; }
        public RegisterCourseModel RegisterCourse { get; set; }
    }
}
 