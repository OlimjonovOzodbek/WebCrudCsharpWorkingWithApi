using System.Xml.Linq;
using WebApplication1.Models;
using WebApplication1.ModelsTDO;
using WebApplication1.MyServices.IServices;
using WebApplication1.Repositories;

namespace WebApplication1.MyServices.Services
{
    public class TeacherService : ITeacherService
    {
        public ITeacherRepository _ts;
        public TeacherService(ITeacherRepository ts)
        {
            _ts = ts;
        }
        public string Create(Teacher_TDO teacher)
        {
            if (teacher == null || teacher.full_name == "")
            {
                return "Name is null";
            }
            return _ts.Create(teacher);
        }

        public string Delete(int id)
        {
            if (id < 0)
            {
                return "Id can not be less then 1";
            }
            return _ts.Delete(id);
        }

        public List<Teacher> Get()
        {
            return _ts.Get();
        }

        public string Patch(int id, string name)
        {
            if (id < 0 || name == "")
            {
                return "ID or Name is empty or id is less than 1";
            }
            return Patch(id, name);
        }

        public string Put(int id, string Name, int age, string salary, string phone)
        {
            if (id < 0 || Name == "")
            {
                return "ID or Name is empty or id is less than 1";
            }
            return Put(id, Name, age, salary, phone);
        }
    }
}
