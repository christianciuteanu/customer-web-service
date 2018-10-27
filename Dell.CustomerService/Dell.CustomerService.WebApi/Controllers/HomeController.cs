using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace Dell.CustomerService.Web.Api.Controllers
{
	[Route("api/[controller]")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			var asm = Assembly.GetExecutingAssembly();

			var actionsList = asm.GetTypes()
				.Where(type => typeof(Controller).IsAssignableFrom(type))
				.SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
				.Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
				.Select(x => new { Controller = x.DeclaringType.Name, Action = x.Name })
				.OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();

			return Ok(actionsList);
		}
	}
}