using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.WebApi.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var cars = CarsContext.LuxuryCars.ToList();
            return Ok(cars);
        }
        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Id cannot be empty.");

            var car = CarsContext.LuxuryCars.FirstOrDefault(x => x.Id == id);

            if (car is null)
                return NotFound("The car requested with given Id is not found.");

            return Ok(car);

        }
    }
}

