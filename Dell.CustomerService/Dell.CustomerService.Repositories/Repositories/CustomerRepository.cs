using System.Threading.Tasks;
using Dell.CustomerService.Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dell.CustomerService.Domain.Repositories
{
	public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
	{
		public CustomerRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{ }


		public async Task<Customer> GetCustomerByEmailAsync(string email)
		{
			return await GetAll().FirstOrDefaultAsync(c => c.Email == email);
		}
	}
}