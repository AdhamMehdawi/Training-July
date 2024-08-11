namespace WebApplication2.DataAccess.Models
{
    public class SectionCorseModel
    {
        public int Id { get; set; }
        public int courseId   { get; set; }
        public int SectionId   { get; set; } 
        public CourceModel course { get; set; }
        public SectionModel Section { get; set; }
    }
}
