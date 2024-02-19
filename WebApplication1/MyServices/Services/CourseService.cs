using WebApplication1.Models;
using WebApplication1.ModelsTDO;
using WebApplication1.MyServices.IServices;
using WebApplication1.Repositories;

namespace WebApplication1.MyServices.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _cS;
        public CourseService(ICourseRepository cs)
        {
            _cS = cs;
        }
        public string Create(Cource_TDO course)
        {
            if (course == null || course.name == "")
            {
                return "Name is null";
            }
            return _cS.Create(course);
        }

        public string Delete(int id)
        {
            if (id < 0)
            {
                return "Id can not be less then 1";
            }
            return _cS.Delete(id);
        }

        public List<Course> Get()
        {
            return _cS.Get();
        }

        public string Patch(int id, string name)
        {
            if (id < 0 || name == "")
            {
                return "ID or Name is empty or id is less than 1";
            }
            return _cS.Patch(id, name);
        }

        public string Put(int id, string Name, string duration, string student_amount, int teacher_id)
        {
            if (id < 0 || Name == "")
            {
                return "ID or Name is empty or id is less than 1";
            }
            return _cS.Put(id, Name, duration, student_amount, teacher_id);
        }
    }
}
