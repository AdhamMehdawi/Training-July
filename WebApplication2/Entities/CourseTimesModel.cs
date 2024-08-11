namespace WebApplication2.Entities
{
    public class CourseTimesModel
    {
        public int Id { get; set; }
        public RegisterCourseModel RegisterCourse { get; set; }
        public int RegisterCourseId { get; set; }
        public string Day { get; set; }
        public TimeSpan StartTime { get; set; } 
        public TimeSpan EndTime { get; set; }

        public HallModel Hall { get; set; }
        public int HallId { get; set; }

    }
}
