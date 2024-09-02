namespace WebApplication2.DataAccess.Models
{
    public class SectionCourseModel
    {
        public int Id { get; set; }
        public int courseId   { get; set; }
        public int SectionId   { get; set; } 
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }

        public CourseModel course { get; set; }
        public SectionModel Section { get; set; } 
        public int TeacherId { get; set; }
        public TeacherModel Teacher { get; set; }
        public List<RegistrationModel> RegistredStudents { get; set; }

    }
}
