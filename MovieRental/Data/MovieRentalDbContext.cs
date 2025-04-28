using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace MovieRental.Data
{
	public class MovieRentalDbContext : DbContext
	{
		public DbSet<Models.Movie.Movie> Movies { get; set; }
		public DbSet<Models.Rental.Rental> Rentals { get; set; }
        public DbSet<Models.Customer.Customer> Customers { get; set; }

        private string DbPath { get; }

		public MovieRentalDbContext()
		{
			var folder = Environment.SpecialFolder.LocalApplicationData;
			var path = Environment.GetFolderPath(folder);
			DbPath = System.IO.Path.Join(path, "movierental.db");
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlite($"Data Source={DbPath}");
	}
}
