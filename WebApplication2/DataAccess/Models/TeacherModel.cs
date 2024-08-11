namespace WebApplication2.DataAccess.Models
{
    public class TeacherModel
    {
       public int id { get; set; }
       public string name { get; set; }

       public string Email { get; set; }

        
       public List<CourseClassModel> Courses { get; set; }

    }
}
