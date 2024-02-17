using WebApplication1.Models;
using WebApplication1.ModelsTDO;

namespace WebApplication1.MyServices.IServices
{
    public interface IStudentService
    {
        public string Create(Student_TDO student);
        public string Put(int id, string Name, int age, int group, string phone);
        public string Delete(int id);
        public List<Student> Get();
        public string Patch(int id, string Name);
    }
}
