using System;

namespace Dell.CustomerService.Web.ApiContracts.Customers
{
	public class CustomerResponseData : CustomerRequestData
	{
		public Guid Id { get; set; }
	}
}