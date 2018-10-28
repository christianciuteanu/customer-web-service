using System;
using System.Threading.Tasks;
using Dell.CustomerService.Domain;
using Dell.CustomerService.Domain.Data.Entities;
using Dell.CustomerService.Web.ApiContracts.Customers;
using Dell.CustomerService.Web.ApiServices;
using Moq;
using NUnit.Framework;

namespace Dell.Customers.Tests
{
	[TestFixture]
	public class CustomerServiceTests
	{
		private Mock<IUnitOfWork> _mockUnitOfWork;
		private Mock<ICustomerService> _mockCustomerService;
		private CustomerService.Web.ApiServices.Services.CustomerService _service;

		[SetUp]
		public void Setup()
		{
			_mockUnitOfWork = new Mock<IUnitOfWork>();
			_mockCustomerService = new Mock<ICustomerService>();
			_service = new CustomerService.Web.ApiServices.Services.CustomerService(_mockUnitOfWork.Object);
		}

		[Test]
		public void AddUpdateCustomerAsyncShouldThrowNullReferenceExceptionWithEmptyEmail()
		{
			//Arrange
			var requestData = new CustomerRequestData
			{
				Email = "",
				Name = "Customer 1"
			};
			
			//Act 
			var result = _service.AddUpdateCustomerAsync(requestData);

			//Assert
			Assert.ThrowsAsync<NullReferenceException>(() => result);
		}

		[Test]
		public void AddUpdateCustomerAsyncShouldThrowNullReferenceExceptionWithEmptyName()
		{
			//Arrange
			var requestData = new CustomerRequestData
			{
				Email = "customer1@test.ro",
				Name = ""
			};

			//Act 
			var result = _service.AddUpdateCustomerAsync(requestData);

			//Assert
			Assert.ThrowsAsync<NullReferenceException>(() => result);
		}

		[Test]
		public void AddUpdateCustomerAsyncShouldAddNewCustomer()
		{
			//Arrange
			_mockUnitOfWork.Setup(uow => uow.CustomerRepository.GetCustomerByEmailAsync("customer1@test.ro")).ReturnsAsync(new Customer
			{
				Id = new Guid("e0c783fb-a4db-4108-bb36-36d507750b52"),
				Email = "customer1@test.ro",
				Name = "Customer 1"
			});

			//Act 
			var result = _service.AddUpdateCustomerAsync(new CustomerRequestData
			{
				Email = "customer1@test.ro",
				Name = "Customer 1"
			}).Result;

			//Assert
			Assert.AreEqual(result.Id, new Guid("e0c783fb-a4db-4108-bb36-36d507750b52"));
		}
	}
}
