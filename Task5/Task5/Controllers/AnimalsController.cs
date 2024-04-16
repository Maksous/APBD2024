using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Task5.Models;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private readonly IConfiguration _configuration;
    public AnimalsController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private List<Dictionary<string, object>> ConvertDataTableToList(DataTable dt)
    {
        var columns = dt.Columns.Cast<DataColumn>();
        return dt.Rows.Cast<DataRow>()
            .Select(row => columns.ToDictionary(column => column.ColumnName, column => row[column])).ToList();
    }

    // GET: api/animals
    [HttpGet]
    public IActionResult GetAnimals(string orderBy = "name")
    {
        string query = $"SELECT * FROM Animals ORDER BY {orderBy}";
        DataTable table = new DataTable();
        string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        {
            myCon.Open();
            using (SqlCommand myCommand = new SqlCommand(query, myCon))
            {
                using (SqlDataReader myReader = myCommand.ExecuteReader())
                {
                    table.Load(myReader);
                }
            }
            myCon.Close();
        }

        var list = ConvertDataTableToList(table);
        return Ok(list);
    }

    // POST: api/animals
    [HttpPost]
    public IActionResult PostAnimal(Animal animal)
    {
        string query = @"
           INSERT INTO Animals (Name, Description, Category, Area) 
           VALUES (@Name, @Description, @Category, @Area)";
        DataTable table = new DataTable();
        string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
        SqlDataReader myReader;
        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        {
            myCon.Open();
            using (SqlCommand myCommand = new SqlCommand(query, myCon))
            {
                myCommand.Parameters.AddWithValue("@Name", animal.Name);
                myCommand.Parameters.AddWithValue("@Description", animal.Description);
                myCommand.Parameters.AddWithValue("@Category", animal.Category);
                myCommand.Parameters.AddWithValue("@Area", animal.Area);
                myReader = myCommand.ExecuteReader();
                table.Load(myReader);
                myReader.Close();
                myCon.Close();
            }
        }
        return new JsonResult("Added Successfully");
    }

    // Further methods for PUT and DELETE to be added here
}