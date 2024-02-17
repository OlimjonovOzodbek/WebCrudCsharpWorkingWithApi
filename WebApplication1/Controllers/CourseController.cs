using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using WebApplication1.Models;
using WebApplication1.ModelsTDO;
using WebApplication1.MyServices.IServices;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ICourseService _cr;
        public CourseController(ICourseService cr)
        {
            _cr = cr;
        }
        [HttpGet]
        public List<Course> Get()
        {
            return _cr.Get();
        }

        [HttpPost]
        public string Create(Cource_TDO course)
        {
            return _cr.Create(course);
        }
        [HttpDelete]
        public string Delete(int id)
        {
            return _cr.Delete(id);
        }
        [HttpPatch]
        public string Patch(int id, string Name)
        {
            return _cr.Patch(id, Name);
        }
        [HttpPut]
        public string Put(int id, string Name, string duration, string student_amount, int teacher_id)
        {
            return _cr.Put(id, Name, duration, student_amount, teacher_id);
        }
    }
}

