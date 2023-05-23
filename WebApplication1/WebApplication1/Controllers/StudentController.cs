using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("demo/[action]")]
    public class StudentController : ControllerBase
    {

        List<Student> students = null;
       public StudentController() {
            students = new List<Student>() {
            new Student(){ Id=1,Name="anish",Description="student"},
            new Student(){ Id=2,Name="rohit",Description="monitor"}
            };
        }

        [HttpGet(Name ="getStudentName")]
        public String Student() 
        {
            return "this is student controller";
        }

        [HttpGet(Name ="getAllStudent")]

        public List<Student> getAllStudents()
        {
            return students;
        }

        [HttpPost(Name ="postStudent")]
        public List<Student> createStudent(Student st) { 
          students.Add(st);
            return students;
        }
    }
}
