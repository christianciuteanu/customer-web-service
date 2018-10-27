using System;
using System.Threading.Tasks;
using Dell.CustomerService.Domain.Repositories;

namespace Dell.CustomerService.Domain
{
	public interface IUnitOfWork: IDisposable
    {
	    ICustomerRepository CustomerRepository { get; }
	    Task SaveAsync();
    }
}
