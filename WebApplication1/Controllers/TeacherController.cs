using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ModelsTDO;
using WebApplication1.MyServices.IServices;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : Controller
    {
        public ITeacherService _tr;
        public TeacherController(ITeacherService tr)
        {
            _tr = tr;
        }
        [HttpGet]
        public List<Teacher> Get()
        {
            try
            {
                return _tr.Get();
            }
            catch (Exception ex)
            {
                return new List<Teacher>();
            }
        }
        [HttpPost]
        public string Create(Teacher_TDO teacher)
        {
            
            try
            {
                return _tr.Create(teacher);
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
                return _tr.Delete(id);
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
                return _tr.Patch(id, Name);
            }
            catch (Exception ex)
            {
                return "Service ERROR";
            }
        }
        [HttpPut]
        public string Put(int id, string Name, int age, string salary, string phone)
        {
            
            try
            {
                return _tr.Put(id, Name, age, salary, phone);
            }
            catch (Exception ex)
            {
                return "Service ERROR";
            }
        }

    }
}
