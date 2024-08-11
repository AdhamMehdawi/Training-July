namespace WebApplication2.Entities
{
    public class TeacherModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<RegisterCourseModel> Courses { get; set; }
    }
}
