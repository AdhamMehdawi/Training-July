namespace WebApplication2.DataAccess.Models
{
    public class ClassModel
    {
        public int id { get; set; }
        public char name { get; set; }

        public DateTime creadetAt { get; set; }

        public List<RegistrationModel> RegistredStudents { get; set; }
    }
}
