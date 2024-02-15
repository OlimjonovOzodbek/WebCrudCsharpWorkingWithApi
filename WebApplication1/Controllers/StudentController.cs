using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Npgsql;
using Dapper;
using WebApplication1.ModelsTDO;

namespace WebApplication1.Controllers
{
        [Route("api/[controller]/[action]")]
        [ApiController]
    public class StudentController : Controller
    {
        private string CONNECTIONSTRING = "Server=127.0.0.1;Port=5432;Database=MyData;User Id=postgres;Password=admin;";
        [HttpGet]
        public List<Student> GetDapper()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
            {
                string query = "select * from students";
                var lst = connection.Query<Student>(query).ToList();
                return lst;
            }
        }

        [HttpPost]
        public string PostDapper(Student_TDO student) 
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
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
        [HttpDelete]
        public string DeleteDappe(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
            {
                string query = "Delete from students where id = @id";
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
                string query = $"update students set full_name = @name where id = @id";
                int status = connection.Execute(query, new { id = id, name = Name });

                return $"O'zgartirildi";
            }
        }
        [HttpPut]
        public string PutDapper(int id, string Name,int age,int group,string phone)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
            {
                string query = $"update students set full_name = @name," +
                    $"age = @age,student_group = @group,phone = @phone where id = @id";
                int status = connection.Execute(query, new { id = id, name = Name,
                age = age,group = group,phone = phone});

                return $"O'zgartirildi";
            }
        }
    }
}
//student_id full_name age student_group phone
