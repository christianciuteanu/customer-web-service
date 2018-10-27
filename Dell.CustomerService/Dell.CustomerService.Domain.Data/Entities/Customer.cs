using System;

namespace Dell.CustomerService.Domain.Data.Entities
{
	public class Customer : IEntity
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Email { get; set; }
	}
}