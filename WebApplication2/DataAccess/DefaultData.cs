using WebApplication2.DataAccess.Models;

namespace WebApplication2.DataAccess
{
    public class DefaultData
    {
        public List<TeacherModel> getTeachers()
        {
            var teachers = new List<TeacherModel>();
            for (int i = 1; i <= 5; i++)
            {
                var teacher = new TeacherModel();
                string name =
                1 == i ? "Ahmad Salem" :
                2 == i ? "Maher Mohammad" :
                3 == i ? "Salma Mostafa" :
                4 == i ? "Rabab Hasan" :
                5 == i ? "Radwan Mahmoud" : "unknown";
                teacher.Id = i;
                teacher.FullName = name;
                teachers.Add(teacher);
            }
            return teachers;
        }

        public List<SemesterModel> getSemesters()
        {
            var semesters = new List<SemesterModel>();
            for (int i = 1; i <= 3; i++)
            {
                var semester = new SemesterModel();
                string name =
                1 == i ? "First Semester" :
                2 == i ? "Second Semester" :
                3 == i ? "Summer Semester" : "unknown";
                semester.SemesterNumber = i;
                semester.SemesterName = name;
                semesters.Add(semester);
            }
            return semesters;
        }

        public List<SectionModel> getSections()
        {
            var sections = new List<SectionModel>();
            for (int i = 1; i <= 5; i++)
            {
                var section = new SectionModel();
                section.Id = i;
                section.Name = "Section " + i;
                sections.Add(section);
            }
            return sections;
        }

        public List<CourseModel> getCourses()
        {
            var courses = new List<CourseModel>();
            for (int i = 1; i <= 10; i++)
            {
                var course = new CourseModel();
                string name =
                1 == i ? "Multimedia" :
                2 == i ? "Principles of Computer Networks" :
                3 == i ? "Introduction to databases" :
                4 == i ? "Graphic Evolution and Image Processing" :
                5 == i ? "Technical English" :
                6 == i ? "Web Programming" :
                7 == i ? "Physical Activity" :
                8 == i ? "Software Applications" :
                9 == i ? "Advanced Databases" :
                10 == i ? "Web Server Administration" : "unknown";
                course.Id = i+1000;
                course.Name = name;
                courses.Add(course);
            }
            return courses;
        }

        public List<StudentModel> getStudents()
        {
            var students = new List<StudentModel>(){
            new StudentModel()
                {
                    Id = 1,
                    City = "Ramallah",
                    Name = "Lina Saeed",
                    Email = "lina.saeed@example.com",
                    PhoneNumber = "0598765432"
                },
            new StudentModel()
                {
                    Id = 2,
                    City = "Nablus",
                    Name = "Omar Nasser",
                    Email = "omar.nasser@example.com",
                    PhoneNumber = "0599876543"
                },
            new StudentModel()
            {
            Id = 3,
            City = "Hebron",
            Name = "Maya Ibrahim",
            Email = "maya.ibrahim@example.com",
            PhoneNumber = "0599987654"
            },
            new StudentModel()
                {
                    Id = 4,
                    City = "Jenin",
                    Name = "Hassan Ali",
                    Email = "hassan.ali@example.com",
                    PhoneNumber = "0599998765"
                },
            new StudentModel()
                {
                    Id = 5,
                    City = "Bethlehem",
                    Name = "Dana Mustafa",
                    Email = "dana.mustafa@example.com",
                    PhoneNumber = "0598887654"
                },
            new StudentModel()
                {
                    Id = 6,
                    City = "Jericho",
                    Name = "Sami Fares",
                    Email = "sami.fares@example.com",
                    PhoneNumber = "0597776543"
                },
            new StudentModel()
                {
                    Id = 7,
                    City = "Gaza",
                    Name = "Yara Hani",
                    Email = "yara.hani@example.com",
                    PhoneNumber = "0596665432"
                },
            new StudentModel()
                {
                    Id = 8,
                    City = "Tulkarm",
                    Name = "Nour Adel",
                    Email = "nour.adel@example.com",
                    PhoneNumber = "0595554321"
                },
            new StudentModel()
                {
                    Id = 9,
                    City = "Qalqilya",
                    Name = "Fadi Hassan",
                    Email = "fadi.hassan@example.com",
                    PhoneNumber = "0594443210"
                },
            new StudentModel()
                {
                    Id = 10,
                    City = "Rafah",
                    Name = "Lama Tamer",
                    Email = "lama.tamer@example.com",
                    PhoneNumber = "0593332109"
                }
            };
            return students;
        }


        public List<SectionCourseModel> getSectionCourse()
        {


        var sectionsCourse = new List<SectionCourseModel>();
            for (int i = 1; i <= 10; i++)
            {
            
                var sectionCourse = new SectionCourseModel();
                sectionCourse.Id = i;
                sectionCourse.courseId = i+1000;
                sectionCourse.StartTime =i%2==0? new TimeSpan(9, 0, 0): new TimeSpan(11, 0, 0);
                sectionCourse.EndTime = i % 2 == 0 ? new TimeSpan(11, 0, 0) : new TimeSpan(13, 0, 0);
                sectionCourse.SectionId = 1;
                sectionCourse.TeacherId = i > 5 ? i - 5 : i;
                sectionsCourse.Add(sectionCourse);

            }
            return sectionsCourse;
        }

        

        public List<RegistrationModel> getRegistration()
        {
            int counter = 0;
            var registrations = new List<RegistrationModel>();
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 7; j++)
                {
                    var registration = new RegistrationModel();
                    registration.Id = ++counter;
                    registration.StudentId = j;
                    registration.RegistrationYear = DateTime.Now.Year;
                    registration.SectionCourseId = i;
                    registration.SemesterId = 1;
                    registrations.Add(registration);

                }
            }
            return registrations;
        }







    }
}