using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Npgsql;
using Dapper;
using WebApplication1.ModelsTDO;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : Controller
    {
        public IStudentRepository _st;
        public StudentController(IStudentRepository st)
        {
            _st = st;
        }
        [HttpGet]
        public List<Student> Get()
        {
            try
            {
                return _st.Get();
            }
            catch (Exception ex)
            {
                return new List<Student>();
            }
        }

        [HttpPost]
        public string Post(Student_TDO student)
        {
            if (student == null || student.full_name == "")
            {
                return "Name is null";
            }
            try
            {
                return _st.Create(student);
            }
            catch (Exception ex)
            {
                return "Service ERROR";
            }
        }
        [HttpDelete]
        public string Delete(int id)
        {
            if (id < 0)
            {
                return "Id can not be less then 1";
            }
            try
            {
                return _st.Delete(id);
            }
            catch (Exception ex)
            {
                return "Service ERROR";
            }
        }
        [HttpPatch]
        public string Patch(int id, string Name)
        {
            if (id < 0 || Name == "")
            {
                return "ID or Name is empty or id is less than 1";
            }
            try
            {
                return _st.Patch(id, Name);
            }
            catch (Exception ex)
            {
                return "Service ERROR";
            }
        }
        [HttpPut]
        public string Put(int id, string Name, int age, int group, string phone)
        {
            if (id < 0 || Name == "")
            {
                return "ID or Name is empty or id is less than 1";
            }
            try
            {
                return _st.Put(id, Name, age, group, phone);
            }
            catch (Exception ex)
            {
                return "Service ERROR";
            }
        }
    }
}
//student_id full_name age student_group phone
