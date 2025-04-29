using Microsoft.EntityFrameworkCore;
using MovieRental.Data;

namespace MovieRental.Models.Rental
{
    public class RentalFeatures : IRentalFeatures
    {
        private readonly MovieRentalDbContext _movieRentalDb;
        public RentalFeatures(MovieRentalDbContext movieRentalDb)
        {
            _movieRentalDb = movieRentalDb;
        }

        public async Task<List<Rental>> GetAll()
        {
            var allRentals = await _movieRentalDb.Rentals.ToListAsync();
            return allRentals;
        }

        public async Task<Rental> Save(Rental rental)
        {
            await _movieRentalDb.Rentals.AddAsync(rental);
            await _movieRentalDb.SaveChangesAsync();

            return rental;
        }

        
        public async Task<IEnumerable<Rental>> GetRentalsByCustomerName(string customerName)
        {
            return await _movieRentalDb.Rentals.Where(p => p.Customer != null && p.Customer.CustomerName.Equals(customerName)).ToListAsync(); ;
        }

    }
}
