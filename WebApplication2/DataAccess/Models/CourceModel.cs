﻿namespace WebApplication2.DataAccess.Models
{
    public class CourceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RegistrationModel> RegistredStudents { get; set; }

       
    }
}
