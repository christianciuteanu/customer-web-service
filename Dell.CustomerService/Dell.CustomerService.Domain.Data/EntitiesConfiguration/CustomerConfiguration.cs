using Dell.CustomerService.Domain.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dell.CustomerService.Domain.Data.EntitiesConfiguration
{
	public class CustomerConfiguration
	{
		public CustomerConfiguration(EntityTypeBuilder<Customer> entityBuilder)
		{
			entityBuilder.HasKey(t => t.Id);
			entityBuilder.Property(t => t.Email).IsRequired();
			entityBuilder.Property(t => t.Name).IsRequired();
		}
	}
}