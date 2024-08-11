namespace WebApplication2.DataAccess.Models
{
    public class SemesterModel
    {
        public int SemesterNumber { get; set; }
        public string SemesterName { get; set; }

        public List<RegistrationModel> Registration { get; set; }
    }
}
