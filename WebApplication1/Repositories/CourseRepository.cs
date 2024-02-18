using Dapper;
using Npgsql;
using WebApplication1.Models;
using WebApplication1.ModelsTDO;

namespace WebApplication1.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public IConfiguration _config;
        public CourseRepository(IConfiguration conf)
        {
            _config = conf;
        }
        public string Create(Cource_TDO course)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("Def")))
            {
                string querry = "insert into Course (name,duration,student_amount,teacher_id) " +
                    "values (@name,@duration,@student_amount,@teacher_id);";
                connection.Execute(querry, new
                {
                    name = course.name,
                    duration = course.duration,
                    student_amount = course.student_amount,
                    teacher_id = course.teacher_id
                });
                return "Yozildi";
            }
        }

        public string Delete(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("Def")))
            {
                string query = "Delete from course where id = @id";
                connection.Execute(query, new
                {
                    id = id
                });
                return "O'chirildi!";
            }
        }

        public List<Course> Get()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("Def")))
            {
                string query = "select * from course";
                var lst = connection.Query<Course>(query).ToList();
                return lst;
            }
        }

        public string Patch(int id, string name)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("Def")))
            {
                string query = $"update course set name = @name where id = @id";
                int status = connection.Execute(query, new { id = id, name = name });

                return $"O'zgartirildi";
            }
        }

        public string Put(int id, string Name, string duration, string student_amount, int teacher_id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("Def")))
            {
                string query = $"update course set name = @name," +
                    $"duration = @duration,student_amount = @student_amount,teacher_id = @teacher_id where id = @id";
                int status = connection.Execute(query, new
                {
                    id = id,
                    name = Name,
                    duration = duration,
                    student_amount = student_amount,
                    teacher_id = teacher_id
                });

                return $"O'zgartirildi";
            }
        }
    }
}
