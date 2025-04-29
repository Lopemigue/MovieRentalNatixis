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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rentals = await _features.GetAll();

            if (rentals == null || !rentals.Any())
            {
                return NotFound(new { message = "Rentals not found" });
            }
            return Ok(rentals);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Models.Rental.Rental rental)
        {
            if (rental== null)
            {
                return BadRequest(new { message = "Invalid rental data." });
            }

            try
            {
                var savedRental = _features.Save(rental);
                return Ok(savedRental);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while saving the rental." });
            }
        }

        [HttpGet("by-customer-name")]
        public async Task<IActionResult> GetRentalByCustomer([FromQuery] string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName))
            {
                return BadRequest(new { message = "Query parameter 'customerName' is required." });
            }

            var rentals = await _features.GetRentalsByCustomerName(customerName);

            if (rentals==null || !rentals.Any())
            {
                return NotFound(new { message = $"No rentals found for customer '{customerName}'." });
            }

            return Ok(rentals);
        }

    }
}
