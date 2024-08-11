namespace WebApplication2.DTOs
{
    public class RegisterCourseDTO
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public int BranchId { get; set; }
        public int SemesterId { get; set; }
    }
}
