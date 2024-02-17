using WebApplication1.Models;
using WebApplication1.ModelsTDO;
using WebApplication1.MyServices.IServices;

namespace WebApplication1.MyServices.Services
{
    public class TeacherService : ITeacherService
    {
        public ITeacherService _ts;
        public TeacherService(ITeacherService ts)
        {
            _ts = ts;
        }
        public string Create(Teacher_TDO teacher)
        {
            return _ts.Create(teacher);
        }

        public string Delete(int id)
        {
            return _ts.Delete(id);
        }

        public List<Teacher> Get()
        {
            return _ts.Get();
        }

        public string Patch(int id, string name)
        {
            return Patch(id,name);
        }

        public string Put(int id, string Name, int age, string salary, string phone)
        {
            return Put(id,Name,age,salary,phone);
        }
    }
}
