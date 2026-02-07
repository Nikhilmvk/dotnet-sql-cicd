using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SimpleDotNetSqlApi.Models;

namespace SimpleDotNetSqlApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _config;

        public UsersController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            using SqlConnection con = new SqlConnection(
                _config.GetConnectionString("DefaultConnection"));

            con.Open();
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Users (Name, Email) VALUES (@Name, @Email)", con);

            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.ExecuteNonQuery();

            return Ok("User added successfully");
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = new List<User>();

            using SqlConnection con = new SqlConnection(
                _config.GetConnectionString("DefaultConnection"));

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users", con);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new User
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString()
                });
            }

            return Ok(users);
        }
    }
}
