using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SettingController : ControllerBase
    {
        List<Student> listOfStudent;
        public SettingController()
        {
            FilListOfStudent();
        }

        void FilListOfStudent()
        {
            listOfStudent = new List<Student>();
            for (int i = 0; i < 20; i++)
            {
                var student = new Student();
                student.Id = i;
                student.Name = "A_" + i.ToString();
                student.Dob = DateTime.Now;
                student.IsActive = i % 2 == 0;
                student.Address = new Address();
                student.Address.Street = "street_" + i;
                student.Address.City = "City_" + i;
                student.Address.AddressDescription = "Description_" + i;
                student.BuildingAddress = new List<Address>();
                for (int j = 0; j < 3; j++)
                {
                    var buildingAddress = new Address();
                    buildingAddress.AddressDescription = "Description_" + i + "_" + j;
                    buildingAddress.City = "City" + i + "_" + j;
                    buildingAddress.Street = "Street" + i + "_" + j;
                    student.BuildingAddress.Add(buildingAddress);
                }


                listOfStudent.Add(student);
            }
        }

        [HttpGet("Get10Student")]
        public IActionResult Get10Student()
        {
            if (listOfStudent == null || !listOfStudent.Any())
            {
                return NotFound();
            }
            return Ok(listOfStudent);
        }


        [HttpGet("Find/{id}")]
        public IActionResult FindStudent(int id)
        {
            Student? result = FindStudentById(id);
            if (result == null)
                return NotFound();
            if (result.IsActive == false) // if (!result.IsActive)
                return BadRequest("The student is inactive..");
            return Ok(result);
        }

        private Student? FindStudentById(int id)
        {
            foreach (var st in listOfStudent)
            {
                if (st.Id == id) return st;
            }
            return null;
        }


        [HttpPost("AddStudent")]
        public IActionResult AddStudent(Student Student)
        {
            //   var isvalid=checkifstudentIdIsValid(Student);
            //if (isvalid == false)
            //{
            //    return BadRequest();
            //}
            if (Student != null)
            {
                Student? student = FindStudentById(Student.Id);
                if (student != null)
                {
                    return BadRequest("Student Already exists");
                }
            }

            //if (Student.Dob == default)
            //{
            //    return BadRequest("The Dob is required field ");
            //}
            listOfStudent.Add(Student);
            return Ok(listOfStudent);
        }

        private bool checkifstudentIdIsValid(Student st)
        {
            if (st.Id > 10000 && st.Id < 10000000)
            {
                return true;
            }

            return false;
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            var student = FindStudentById(id);
            if (student != null)
            {
                listOfStudent.Remove(student);
                return Ok(listOfStudent);
            }
            return NotFound();
        }

    }

    public class Student
    {
        [Required]
        [Range(10, 20000)]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "The dob field is required. ")]
        public DateTime? Dob { get; set; }
        [Required]
        public bool IsActive { get; set; }
        //[EmailAddress]
        //public string Email { get; set; }

        public Address Address { get; set; }

        public List<Address> BuildingAddress { get; set; }

        //[Phone(ErrorMessage = "")]
        //[RegularExpression("[0-9]*",ErrorMessage = "")]
        //  public bool PhoneNumber { get; set; }

    }

    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string AddressDescription { get; set; }
    }
}
