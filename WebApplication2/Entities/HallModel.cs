namespace WebApplication2.Entities
{
    public class HallModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<CourseTimesModel> CourseTimes { get; set; }
    }
}
