using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Configuration;

namespace Dell.CustomerService.Web.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			BuildWebHost(args).Run();

			//RunServiceAsAService(args);
		}

		/// <summary>
		/// Use this method to Host ASP.NET Core in a Windows Service
		/// </summary>
		/// <param name="args"></param>
		public static void RunServiceAsAService(string[] args)
		{
			var isService = !(Debugger.IsAttached || args.Contains("--console"));
			var pathToContentRoot = Directory.GetCurrentDirectory();
			var webHostArgs = args.Where(arg => arg != "--console").ToArray();

			if (isService)
			{
				var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
				pathToContentRoot = Path.GetDirectoryName(pathToExe);
			}

			var host = WebHost.CreateDefaultBuilder(webHostArgs)
				.UseContentRoot(pathToContentRoot)
				.UseStartup<Startup>()
				.Build();

			if (isService)
			{
				host.RunAsService();
			}
			else
			{
				host.Run();
			}
		}

		/// <summary>
		/// Use this method to run the app re regularly
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseKestrel()
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseConfiguration(new ConfigurationBuilder().AddCommandLine(args).Build())
				.UseIISIntegration()
				.UseStartup<Startup>()
				.Build();
	}
}
