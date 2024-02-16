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
            return _st.Get();
        }

        [HttpPost]
        public string Post(Student_TDO student)
        {
            return _st.Create(student);
        }
        [HttpDelete]
        public string Delete(int id)
        {
            return _st.Delete(id);
        }
        [HttpPatch]
        public string Patch(int id, string Name)
        {
            return _st.Patch(id, Name);
        }
        [HttpPut]
        public string Put(int id, string Name, int age, int group, string phone)
        {
            return _st.Put(id, Name,age,group,phone);
        }
    }
}
//student_id full_name age student_group phone
