namespace WebApplication2.DataAccess.Models
{
    public class EmployeeModel : StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public int DepartmentId { get; set; }
    }
}
