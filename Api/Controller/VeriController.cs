using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeriController : ControllerBase
    {
        private readonly MySqlConnection _connection;
        private const string ConnectionString = "Server=aracyanimda-server.mysql.database.azure.com;Database=aracyanimda-database;Port=3306;User Id=knwmjbedky;Password=C478CKJ6UMSO5DJV$;SSL Mode=Required";

        public VeriController()
        {
            _connection = new MySqlConnection(ConnectionString);
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<string> veriler = new List<string>();

            try
            {
                _connection.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM admin", _connection);
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    veriler.Add(reader.GetString("username"));
                    // Gerekli diğer sütunları da alabilirsin
                }

                _connection.Close();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }

            return veriler;
        }
    }
}
