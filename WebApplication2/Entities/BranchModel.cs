namespace WebApplication2.Entities
{
    public class BranchModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RegisterCourseModel> RegisterCourse { get; set; }
    }
}
