using System.Linq;
using System.Threading.Tasks;
using Dell.CustomerService.Web.ApiContracts.Customers;
using Dell.CustomerService.Web.ApiServices;
using Microsoft.AspNetCore.Mvc;

namespace Dell.CustomerService.Web.Api.Controllers
{
	[Route("api/[controller]")]
	public class CustomersController : Controller
	{
		private readonly ICustomerService _customerService;

		public CustomersController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		[HttpPost("addUpdateCustomer")]
		public async Task<IActionResult> AddUpdateCustomer([FromBody]CustomerRequestData requestData)
		{
			if (!ModelState.IsValid) { return BadRequest(ModelState.Select(e => e.Value.Errors).Where(y => y.Count > 0).ToList()); }

			var returnData = await _customerService.AddUpdateCustomerAsync(requestData);

			return Ok(returnData);
		}
	}
}