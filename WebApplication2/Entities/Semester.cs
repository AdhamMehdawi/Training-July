namespace WebApplication2.Entities
{
    public class SemesterModel
    {
        public int SemesterNumber { get; set; }
        public string SemesterName { get; set; }
        public int Year { get; set; }

        public List<RegisterCourseModel> RegisterdCourses { get; set; }
    }
}
