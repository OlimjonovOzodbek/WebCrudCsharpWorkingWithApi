using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using WebApplication1.Models;
using WebApplication1.ModelsTDO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : Controller
    {
        private string CONNECTIONSTRING = "Server=127.0.0.1;Port=5432;Database=MyData;User Id=postgres;Password=admin;";
        [HttpGet]
        public List<Course> GetDapper()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
            {
                string query = "select * from course";
                var lst = connection.Query<Course>(query).ToList();
                return lst;
            }
        }

        [HttpPost]
        public string PostDapper(Cource_TDO course)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
            {
                string querry = "insert into course (name,duration,student_amount,teacher_id) " +
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
        [HttpDelete]
        public string DeleteDappe(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
            {
                string query = "Delete from course where id = @id";
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
                string query = $"update course set name = @name where id = @id";
                int status = connection.Execute(query, new { id = id, name = Name });

                return $"O'zgartirildi";
            }
        }
        [HttpPut]
        public string PutDapper(int id, string Name, string duration, string student_amount, int teacher_id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING))
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

