using Microsoft.AspNetCore.Mvc;
using MovieRental.Models.Rental;



namespace MovieRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : ControllerBase
    {

        private readonly IRentalFeatures _features;

        public RentalController(IRentalFeatures features)
        {
            _features = features;
        }


        [HttpPost]
        public IActionResult Post([FromBody] Models.Rental.Rental rental)
        {
	        return Ok(_features.Save(rental));
        }

        [HttpGet("by-customer-name")]
        public IEnumerable<Models.Rental.Rental> GetRentalByCustomer([FromQuery] string customerName)
        {
            return _features.GetRentalsByCustomerName(customerName);
        }

    }
}
