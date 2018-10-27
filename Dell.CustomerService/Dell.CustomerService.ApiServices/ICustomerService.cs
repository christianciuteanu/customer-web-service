using System.Threading.Tasks;
using Dell.CustomerService.Web.ApiContracts.Customers;

namespace Dell.CustomerService.Web.ApiServices
{
	public interface ICustomerService
	{
		Task<CustomerResponseData> AddUpdateCustomerAsync(CustomerRequestData requestData);
	}
}