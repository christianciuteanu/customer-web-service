using System;
using System.Threading.Tasks;
using Dell.CustomerService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dell.CustomerService.Domain
{
	public interface IUnitOfWork: IDisposable
	{
		ICustomerRepository CustomerRepository { get; }
		DbContext Context { get; }
	    Task SaveAsync();
    }
}
