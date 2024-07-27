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
            for (int i = 0; i < 10; i++)
            {
                var student = new Student();
                student.Id = i;
                student.Name = "A_" + i.ToString();
                student.Dob = DateTime.Now;
                student.IsActive = i % 2 == 0;
                listOfStudent.Add(student);
            }
        }

        [HttpGet("Get10Student")]
        public List<Student> Get10Student()
        {
            return listOfStudent;
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
        public IActionResult AddStudent(Student st)
        {
            if (st != null)
            {
                Student? student = FindStudentById(st.Id);
                if (student != null)
                {
                    return BadRequest("Student Already exists");
                }
            }
            listOfStudent.Add(st);
            return Ok(listOfStudent);
        }

        [HttpDelete] 
        public IActionResult DeleteStudent(int id)
        {
           var student= FindStudentById(id);
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
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public bool IsActive { get; set; }
    }
}
