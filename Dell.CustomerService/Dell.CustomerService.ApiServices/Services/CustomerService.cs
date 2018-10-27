using System.Threading.Tasks;
using Dell.CustomerService.Domain;
using Dell.CustomerService.Domain.Data.Entities;
using Dell.CustomerService.Web.ApiContracts.Customers;

namespace Dell.CustomerService.Web.ApiServices.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly IUnitOfWork _unitOfWork;

		public CustomerService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<CustomerResponseData> AddUpdateCustomerAsync(CustomerRequestData requestData)
		{
			var existingCustomer = await _unitOfWork.CustomerRepository.GetCustomerByEmailAsync(requestData.Email);

			return await AddUpdateCustomerAsync(existingCustomer, requestData);
		}

		private async Task<CustomerResponseData> AddUpdateCustomerAsync(Customer dbCustomer, CustomerRequestData requestData)
		{
			if (dbCustomer != null)
			{
				dbCustomer.Name = requestData.Name;
				await _unitOfWork.CustomerRepository.Update(dbCustomer.Id, dbCustomer);
				return new CustomerResponseData
				{
					Id = dbCustomer.Id,
					Name = dbCustomer.Name,
					Email = dbCustomer.Email
				};
			}

			await _unitOfWork.CustomerRepository.Create(new Customer
			{
				Name = requestData.Name,
				Email = requestData.Email
			});

			var createdCustomer = await _unitOfWork.CustomerRepository.GetCustomerByEmailAsync(requestData.Email);
			return new CustomerResponseData
			{
				Email = createdCustomer.Email,
				Name = createdCustomer.Name,
				Id = createdCustomer.Id
			};
		}
	}
}