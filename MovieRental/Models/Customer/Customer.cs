using System.ComponentModel.DataAnnotations;

namespace MovieRental.Models.Customer
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string CustomerName { get; set; }

    }
}
