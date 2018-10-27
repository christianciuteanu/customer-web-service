using System.Threading.Tasks;
using Dell.CustomerService.Domain.Repositories;

namespace Dell.CustomerService.Domain
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly CustomersDbContext _customersDbContext;
		private ICustomerRepository _customerRepository;

		public UnitOfWork(CustomersDbContext customersDbContext)
		{
			_customersDbContext = customersDbContext;
		}
		
		public ICustomerRepository CustomerRepository
		{
			get
			{
				return _customerRepository = _customerRepository ?? new CustomerRepository(_customersDbContext);
			}
		}

		public async Task SaveAsync()
		{
			await _customersDbContext.SaveChangesAsync();
		}

		public void Dispose()
		{
			_customersDbContext.Dispose();
		}
	}
}