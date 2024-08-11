namespace WebApplication2.DataAccess.Models
{
    public class CourseClassModel
    {
       public int id { get; set; }
        public int CourseId { get; set; }
       public int ClassId { get; set; }

        public CourceModel Course { get; set; }
        public ClassModel Class { get; set; }


    }
}
