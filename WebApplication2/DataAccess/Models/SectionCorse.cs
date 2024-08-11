namespace WebApplication2.DataAccess.Models
{
    public class SectionCorseModel
    {
        public int Id { get; set; }
        public int courseId   { get; set; }
        public int SectionId   { get; set; } 
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public CourceModel course { get; set; }
        public SectionModel Section { get; set; } 
        public int TeacherId { get; set; }
        public TeacherModel Teacher { get; set; }

    }
}
