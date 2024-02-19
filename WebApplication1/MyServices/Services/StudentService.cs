using WebApplication1.Models;
using WebApplication1.ModelsTDO;
using WebApplication1.MyServices.IServices;
using WebApplication1.Repositories;

namespace WebApplication1.MyServices.Services
{
    public class StudentService : IStudentService
    {
        public IStudentRepository _sc;
        public StudentService(IStudentRepository sc)
        {
            _sc = sc;
        }
        public string Create(Student_TDO student)
        {
            if (student == null || student.full_name == "")
            {
                return "Name is null";
            }
            return _sc.Create(student);
        }

        public string Delete(int id)
        {
            if (id < 0)
            {
                return "Id can not be less then 1";
            }
            return _sc.Delete(id);
        }

        public List<Student> Get()
        {
            return Get();
        }

        public string Patch(int id, string Name)
        {
            if (id < 0 || Name == "")
            {
                return "ID or Name is empty or id is less than 1";
            }
            return Patch(id, Name);
        }

        public string Put(int id, string Name, int age, int group, string phone)
        {
            if (id < 0 || Name == "")
            {
                return "ID or Name is empty or id is less than 1";
            }
            return Put(id, Name, age, group, phone);
        }
    }
}
