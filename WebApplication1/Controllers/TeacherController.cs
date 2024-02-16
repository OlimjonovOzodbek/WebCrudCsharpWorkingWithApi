using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using WebApplication1.Models;
using WebApplication1.ModelsTDO;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : Controller
    {
        public ITeacherRepository _tr;
        public TeacherController(ITeacherRepository tr)
        {
            _tr = tr;
        }
        [HttpGet]
        public List<Teacher> Get()
        {
            return _tr.Get();
        }
        [HttpPost]
        public string Create(Teacher_TDO teacher)
        {
            return _tr.Create(teacher);
        }
        [HttpDelete]
        public string Delete(int id)
        {
            return _tr.Delete(id);
        }
        [HttpPatch]
        public string Patch(int id, string Name)
        {
            return _tr.Patch(id, Name);
        }
        [HttpPut]
        public string Put(int id, string Name, int age, string salary, string phone)
        {
            return _tr.Put(id, Name,age,salary,phone);
        }

    }
}
