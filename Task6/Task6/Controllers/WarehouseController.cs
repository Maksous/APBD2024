using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;
using Task6.Models;

namespace Task6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController : ControllerBase
    {

        //If warehouseDbContext is used
        /*
        private readonly WarehouseDbContext _context;
        public WarehouseController(WarehouseDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult AddProductToWarehouse([FromBody] ProductWarehouseRequest request)
        {
            if (request.Amount <= 0)
            {
                return BadRequest("Amount has to be greater than zero");
            }

            var productExists = _context.Products.Any(p => p.Id == request.ProductId);
            if (!productExists)
            {
                return NotFound($"No product found with Id {request.ProductId}");
            }

            //check whether warehouseExists

            var order = _context.Orders
                .Where(o => o.ProductId == request.ProductId && o.CreatedAt < request.CreatedAt)
                .OrderByDescending(o => o.CreatedAt)
                .FirstOrDefault();
        */

        // If dbcontext is not used

        private readonly string connectionString = "YourConnectionStringGoesHere";

        [HttpPost]
        public IActionResult AddProductToWarehouse([FromBody] ProductWarehouseRequest request)
        {
            if (request.Amount <= 0)
            {
                return BadRequest("Amount has to be greater than zero");
            }
            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();

                try
                {
                    // Add logic to interact with the db
                    // Use Sql commands to check conditions and manipulate data
                    transaction.Commit();
                    return Ok("Product added Succesfully");
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    return StatusCode(500, $"An error occured: {ex.Message}");
                }
            }
        }

        // ExtraTask
        // Adding using StoredProcedures
        /*
        [HttpPost("AddUsingProcedure")]
        public IActionResult AddProductToWarehouseUsingProcedure([FromBody] ProductWarehouseRequest request)
        {
            if (request.Amount <= 0)
            {
                return BadRequest("Amount must be greater than zero.");
            }
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("YourStoredProcedureName", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // set up the parameters
                }
                try
                {
                    command.ExecuteNonQuery();
                    return Ok("product added via stored procvedure successfully.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occured: {ex.Message}");
                }
            }
        }
        */
    }
}
