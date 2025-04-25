namespace MovieRental.Models.Customer;

public interface ICustomerFeatures
{
    Task<Customer> Save(Customer customer);

}

