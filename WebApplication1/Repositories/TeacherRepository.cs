using Dapper;
using Npgsql;
using System.Xml.Linq;
using WebApplication1.Models;
using WebApplication1.ModelsTDO;

namespace WebApplication1.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        public IConfiguration _config;
        public TeacherRepository(IConfiguration conf)
        {
            _config = conf;
        }
        public string Create(Teacher_TDO teacher)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("Def")))
            {
                string querry = "insert into teacher (full_name,age,salary,phone) " +
                    "values (@full_name,@age,@salary,@phone);";
                connection.Execute(querry, new
                {
                    full_name = teacher.full_name,
                    age = teacher.age,
                    salary = teacher.salary,
                    phone = teacher.phone
                });
                return "Yozildi";
            }
        }
        public string Delete(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("Def")))
            {
                string query = "Delete from teacher where id = @id";
                connection.Execute(query, new
                {
                    id = id
                });
                return "O'chirildi!";
            }
        }
        public List<Teacher> Get()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("Def")))
            {
                string query = "select * from teacher";
                var lst = connection.Query<Teacher>(query).ToList();
                return lst;
            }
        }
        public string Put(int id, string Name, int age, string salary, string phone)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("Def")))
            {
                string query = $"update teacher set full_name = @name," +
                    $"age = @age,salary = @salary,phone = @phone where id = @id";
                int status = connection.Execute(query, new
                {
                    id = id,
                    name = Name,
                    age = age,
                    salary = salary,
                    phone = phone
                });

                return $"O'zgartirildi";
            }
        }
        public string Patch(int id, string name)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("Def")))
            {
                string query = $"update teacher set full_name = @name where id = @id";
                int status = connection.Execute(query, new { id = id, name = name });

                return $"O'zgartirildi";
            }
        }
    }
}
