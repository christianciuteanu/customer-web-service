using Microsoft.EntityFrameworkCore;

namespace Dell.CustomerService.Domain
{
	public class CustomersDbContext : DbContext
	{
		public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options)
		{ }

		public virtual DbSet<Customer> Customers { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql(@"Host=localhost;Database=Dell.Customers;Username=postgres;Password=access4dell");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>(entity =>
			{
				entity.ToTable("customers");
				entity.Property(e => e.Id).HasColumnName("id");
				entity.Property(e => e.Email).HasColumnName("email");
				entity.Property(e => e.Name).IsRequired().HasColumnName("name");
			});
		}

	}
}