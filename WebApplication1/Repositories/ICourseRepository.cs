using WebApplication1.Models;
using WebApplication1.ModelsTDO;

namespace WebApplication1.Repositories
{
    public interface ICourseRepository
    {
        public List<Course> Get();
        public string Delete(int id);
        public string Create(Cource_TDO course);
        public string Patch(int id, string name);
        public string Put(int id, string Name, string duration, string student_amount, int teacher_id);
    }
}
