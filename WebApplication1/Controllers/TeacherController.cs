using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using WebApplication1.Models;
using WebApplication1.ModelsTDO;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : Controller
    {
        private string CONNECTIONSTRING = "Server=127.0.0.1;Port=5432;Database=MyData;User Id=postgres;Password=admin;";
        [HttpGet]
        public List<Teacher> GetDapper()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
            {
                string query = "select * from teacher";
                var lst = connection.Query<Teacher>(query).ToList();
                return lst;
            }
        }
        [HttpPost]
        public string PostDapper(Teacher_TDO teacher)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
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
        [HttpDelete]
        public string DeleteDapper(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
            {
                string query = "Delete from teacher where id = @id";
                connection.Execute(query, new
                {
                    id = id
                });
                return "O'chirildi!";
            }
        }
        [HttpPatch]
        public string PatchDapper(int id, string Name)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
            {
                string query = $"update teacher set full_name = @name where id = @id";
                int status = connection.Execute(query, new { id = id, name = Name });

                return $"O'zgartirildi";
            }
        }
        [HttpPut]
        public string PutDapper(int id, string Name, int age, string salary, string phone)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
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

    }
}
