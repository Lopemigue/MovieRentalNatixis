using Microsoft.AspNetCore.Mvc;

namespace MovieRental.Models.Customer;

public interface ICustomerFeatures
{
    Task<Customer> Save(Customer customer);

    Task<List<Customer>> GetAll();

}

