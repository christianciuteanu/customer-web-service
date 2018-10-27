using System;

namespace Dell.CustomerService.Domain.Data.Entities
{
	public interface IEntity
	{
		Guid Id { get; set; }
	}
}