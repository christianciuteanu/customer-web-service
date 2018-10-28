using Dell.CustomerService.Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dell.CustomerService.Domain.Data.EntitiesConfiguration
{
	public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> builder)
		{
			builder.HasKey(t => t.Id);
			builder.Property(t => t.Email).IsRequired();
			builder.Property(t => t.Name).IsRequired();
		}
	}
}