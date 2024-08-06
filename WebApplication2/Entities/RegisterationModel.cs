namespace WebApplication2.Entities
{
    public class RegisterationModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public StudentModel Student { get; set; }
        public CourseModel Course { get; set; }
    }
}
