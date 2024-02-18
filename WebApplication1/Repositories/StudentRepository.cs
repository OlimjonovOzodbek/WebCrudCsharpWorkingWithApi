using Dapper;
using Npgsql;
using WebApplication1.Models;
using WebApplication1.ModelsTDO;

namespace WebApplication1.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public IConfiguration _config;
        public StudentRepository(IConfiguration conf)
        {
            _config = conf;
        }
        public string Create(Student_TDO student)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("Def")))
            {
                string querry = "insert into students (full_name,age,student_group,phone) " +
                    "values (@full_name,@age,@student_group,@phone);";
                connection.Execute(querry, new
                {
                    full_name = student.full_name,
                    age = student.age,
                    student_group = student.student_group,
                    phone = student.phone
                });
                return "Yozildi";
            }
        }

        public string Delete(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("Def")))
            {
                string query = "Delete from students where id = @id";
                connection.Execute(query, new
                {
                    id = id
                });
                return "O'chirildi!";
            }
        }

        public List<Student> Get()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("Def")))
            {
                string query = "select * from students";
                var lst = connection.Query<Student>(query).ToList();
                return lst;
            }
        }

        public string Patch(int id, string Name)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("Def")))
            {
                string query = $"update students set full_name = @name where id = @id";
                int status = connection.Execute(query, new { id = id, name = Name });
                return $"O'zgartirildi";
            }
        }

        public string Put(int id, string Name, int age, int group, string phone)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("Def")))
            {
                string query = $"update students set full_name = @name," +
                    $"age = @age,student_group = @group,phone = @phone where id = @id";
                int status = connection.Execute(query, new
                {
                    id = id,
                    name = Name,
                    age = age,
                    group = group,
                    phone = phone
                });

                return $"O'zgartirildi";
            }
        }
    }
}
