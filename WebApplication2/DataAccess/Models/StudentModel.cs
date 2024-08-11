﻿using WebApplication2.Controllers;

namespace WebApplication2.DataAccess.Models
{
    public class StudentModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; } 
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateOfRegistration { get; set; }
    }
}