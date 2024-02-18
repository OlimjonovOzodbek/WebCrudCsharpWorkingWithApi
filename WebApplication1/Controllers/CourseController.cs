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
            if (course == null || course.name == "")
            {
                return "Name is null";
            }
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
            if (id < 0)
            {
                return "Id can not be less then 1";
            }
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
            if (id < 0 || Name == "")
            {
                return "ID or Name is empty or id is less than 1";
            }
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
            if (id < 0 || Name == "")
            {
                return "ID or Name is empty or id is less than 1";
            }
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

