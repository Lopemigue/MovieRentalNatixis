using Microsoft.AspNetCore.Mvc;
using MovieRental.Models.Customer;

namespace MovieRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerFeatures _features;

        public CustomerController(ICustomerFeatures features)
        {
            _features = features;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _features.GetAll();

            if (customers == null || !customers.Any())
            {
                return NotFound(new { message = "Customers not found" });
            }

            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest(new { message = "Invalid customer data." });
            }

            try
            {
                var savedCustomer = await _features.Save(customer);
                return Ok(savedCustomer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {message= "An error occurred while saving the customer." });
            }
            
            
        }

    }
}
