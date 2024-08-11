
namespace WebApplication2.Entities
{

    public class RegisterCourseModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public int BranchId { get; set; }
        public int SemesterId { get; set; }

        public CourseModel Course { get; set; }
        public TeacherModel Teacher { get; set; }
        public BranchModel Branch { get; set; }
        public SemesterModel Semester { get; set; }

        public List<RegisterStudentModel> RegisterStudents { get; set; }
        public List<CourseTimesModel> CourseTimes { get; set; }
    }
}
