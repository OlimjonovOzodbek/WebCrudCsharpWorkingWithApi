using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ModelsTDO;
using WebApplication1.MyServices.IServices;

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
            try
            {
                return _cr.Get();
            }
            catch (Exception ex)
            {
                return new List<Course>();
            }
        }

        [HttpPost]
        public string Create(Cource_TDO course)
        {
            try
            {
                return _cr.Create(course);
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
                return _cr.Delete(id);
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
                return _cr.Patch(id, Name);
            }
            catch (Exception ex)
            {
                return "Service ERROR";
            }
        }
        [HttpPut]
        public string Put(int id, string Name, string duration, string student_amount, int teacher_id)
        {

            try
            {
                return _cr.Put(id, Name, duration, student_amount, teacher_id);
            }
            catch (Exception ex)
            {
                return "Service ERROR";
            }
        }
    }
}

