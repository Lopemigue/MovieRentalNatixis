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

            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            var savedCustomer = await _features.Save(customer);
            return Ok(savedCustomer);
        }

    }
}
