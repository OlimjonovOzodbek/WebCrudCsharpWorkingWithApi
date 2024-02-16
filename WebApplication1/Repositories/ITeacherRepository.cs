using WebApplication1.Models;
using WebApplication1.ModelsTDO;

namespace WebApplication1.Repositories
{
    public interface ITeacherRepository
    {
        public string Create(Teacher_TDO teacher);
        public string Delete(int id);
        public List<Teacher> Get();
        public string Put(int id, string Name, int age, string salary, string phone);
        public string Patch(int id,string name);
    }
}
