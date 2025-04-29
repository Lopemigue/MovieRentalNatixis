namespace MovieRental.Models.Rental;

public interface IRentalFeatures
{
	Task<Rental> Save(Rental rental);
    Task<IEnumerable<Rental>> GetRentalsByCustomerName(string customerName);
    Task<List<Rental>> GetAll();
}