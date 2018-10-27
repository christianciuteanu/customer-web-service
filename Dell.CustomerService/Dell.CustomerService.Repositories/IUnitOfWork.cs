using Dell.CustomerService.Domain.Repositories;

namespace Dell.CustomerService.Domain
{
	public interface IUnitOfWork
    {
	    ICustomerRepository CustomerRepository { get; }
    }
}
