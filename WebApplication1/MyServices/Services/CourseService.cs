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
            return _cS.Create(course);
        }

        public string Delete(int id)
        {
            return _cS.Delete(id);
        }

        public List<Course> Get()
        {
            return _cS.Get();
        }

        public string Patch(int id, string name)
        {
            return _cS.Patch(id, name);
        }

        public string Put(int id, string Name, string duration, string student_amount, int teacher_id)
        {
            return _cS.Put(id, Name, duration, student_amount, teacher_id);
        }
    }
}
