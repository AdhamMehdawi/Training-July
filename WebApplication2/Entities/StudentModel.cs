namespace WebApplication2.Entities
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }   
        public List<RegisterationModel> Registerations { get; set; }
    }
}
