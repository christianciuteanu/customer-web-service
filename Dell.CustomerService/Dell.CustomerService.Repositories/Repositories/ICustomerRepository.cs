using System.Threading.Tasks;
using Dell.CustomerService.Domain.Data.Entities;

namespace Dell.CustomerService.Domain.Repositories
{
	public interface ICustomerRepository : IGenericRepository<Customer>
	{
		Task<Customer> GetCustomerByEmailAsync(string email);
	}
}
