using Dell.CustomerService.Domain.Data.Entities;
using Dell.CustomerService.Domain.Data.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Dell.CustomerService.Domain
{
	public class CustomersDbContext : DbContext
	{
		public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			new CustomerConfiguration(builder.Entity<Customer>());
		}
	}
}