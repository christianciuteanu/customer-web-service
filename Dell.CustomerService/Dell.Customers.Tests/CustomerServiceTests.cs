using System;
using Dell.CustomerService.Domain;
using Dell.CustomerService.Domain.Data.Entities;
using Dell.CustomerService.Web.ApiContracts.Customers;
using Moq;
using NUnit.Framework;

namespace Dell.Customers.Tests
{
	[TestFixture]
	public class CustomerServiceTests
	{
		[Test]
		public void ServiceCreatesOrUpdatesCustomer()
		{
			var repoMock = new Mock<IUnitOfWork>();
			var requestData = new CustomerRequestData
			{
				Email = "Customer 1",
				Name = "customer1@test.ro"
			};
			var repoResponseData = new Customer
			{
				Id = new Guid("0bb2db98-cfda-4a0e-b751-ac1f1d773d09"),
				Email = "Customer 1",
				Name = "customer1@test.ro"
			};

			repoMock.Setup(r => r.CustomerRepository.GetCustomerByEmailAsync(requestData.Email)).ReturnsAsync(repoResponseData);

			var service = new CustomerService.Web.ApiServices.Services.CustomerService(repoMock.Object);

			var response = service.AddUpdateCustomerAsync(requestData).Result;

			Assert.AreEqual(response.Id, repoResponseData.Id);
			Assert.AreEqual(response.Email, repoResponseData.Email);
			Assert.AreEqual(response.Name, repoResponseData.Name);
		}
	}
}
