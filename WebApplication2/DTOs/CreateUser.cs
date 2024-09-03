namespace WebApplication2.DTOs
{
    public class CreateUser
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastLogin { get; set; }
        public string Password { get; set; }
        public List<string>Roles { get; set; }

    }
}
