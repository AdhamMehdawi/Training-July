namespace WebApplication2.DataAccess.Models
{
    public class Assigment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int RegistrationId { get; set; } 
        public RegistrationModel Registration  { get; set; }

    }
}
