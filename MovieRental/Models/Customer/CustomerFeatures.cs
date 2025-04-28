
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRental.Data;

namespace MovieRental.Models.Customer
{
    public class CustomerFeatures : ICustomerFeatures
    {
        private readonly MovieRentalDbContext _movieRentalDb;
        public CustomerFeatures(MovieRentalDbContext movieRentalDb)
        {
            _movieRentalDb = movieRentalDb;
        }

        public async Task<List<Customer>> GetAll()
        {
            var allCustomers = await _movieRentalDb.Customers.ToListAsync();
            return allCustomers;
        }

        public async Task<Customer> Save(Customer customer)
        {
            await _movieRentalDb.Customers.AddAsync(customer);
            await _movieRentalDb.SaveChangesAsync();

            return customer;
        }

        
    }
}
