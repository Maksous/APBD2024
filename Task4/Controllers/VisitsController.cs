using Microsoft.AspNetCore.Mvc;
using Task4.models;

namespace Task4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitsController : ControllerBase
    {
        // List of visits

        //Retrieve all visits
        [HttpGet]

        //Retrieve visists with specific animal by the Id
        [HttpGet("{animalId}")]

        //Add a new visit
        [HttpPost]

    }
}