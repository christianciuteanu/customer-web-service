using System.Threading.Tasks;
using Dell.CustomerService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dell.CustomerService.Domain
{
	public class UnitOfWork : IUnitOfWork
	{
		private ICustomerRepository _customerRepository;

		public DbContext Context { get; }

		public UnitOfWork(DbContext context)
		{
			Context = context;
		}

		public ICustomerRepository CustomerRepository => _customerRepository ?? new CustomerRepository(this);

		public async Task SaveAsync()
		{
			await Context.SaveChangesAsync();
		}

		public void Dispose()
		{
			Context.Dispose();
		}
	}
}