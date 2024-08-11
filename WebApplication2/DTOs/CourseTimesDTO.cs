namespace WebApplication2.DTOs
{
    public class CourseTimesDTO
    {
        public int Id { get; set; }
        public int RegisterCourseId { get; set; }
        public string Day { get; set; }
        public TimeSpan StartTime { get; set; } 
        public TimeSpan EndTime { get; set; }
        public int HallId { get; set; }
    }
}
