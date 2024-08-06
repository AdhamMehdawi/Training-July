namespace WebApplication2.DataAccess.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Description { get; set; }
    }
}
