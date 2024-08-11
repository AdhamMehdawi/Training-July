namespace WebApplication2.DataAccess.Models
{
    public class CourseClassModel
    {
        int id { get; set; }
        int CourseId { get; set; }
        int ClassId { get; set; }

        public CourceModel Course { get; set; }
        public ClassModel Class { get; set; }


    }
}
