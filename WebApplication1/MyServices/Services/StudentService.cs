using WebApplication1.Models;
using WebApplication1.ModelsTDO;
using WebApplication1.MyServices.IServices;

namespace WebApplication1.MyServices.Services
{
    public class StudentService : IStudentService
    {
        public IStudentService _sc;
        public StudentService(IStudentService sc)
        {
            _sc = sc;
        }
        public string Create(Student_TDO student)
        {
            return _sc.Create(student);
        }

        public string Delete(int id)
        {
            return _sc.Delete(id);
        }

        public List<Student> Get()
        {
            return Get();
        }

        public string Patch(int id, string Name)
        {
            return Patch(id,Name);
        }

        public string Put(int id, string Name, int age, int group, string phone)
        {
            return Put(id,Name,age,group,phone);
        }
    }
}
