using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ModelsTDO;
using WebApplication1.MyServices.IServices;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : Controller
    {
        public IStudentService _st;
        public StudentController(IStudentService st)
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
