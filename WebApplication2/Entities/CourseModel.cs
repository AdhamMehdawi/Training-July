namespace WebApplication2.Entities
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<registrationModel> Registration { get; set; }
    }
}
