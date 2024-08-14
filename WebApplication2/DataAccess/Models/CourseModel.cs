namespace WebApplication2.DataAccess.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SectionCourseModel> SectionCourse { get; set; }
    }
}
