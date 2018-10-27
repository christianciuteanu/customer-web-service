using Dell.CustomerService.Domain;
using Dell.CustomerService.Domain.Repositories;
using Dell.CustomerService.Web.ApiServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dell.CustomerService.Web.Api
{
	public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddDbContext<CustomersDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
	        services.AddTransient<ICustomerService, Web.ApiServices.Services.CustomerService>();
			services.AddScoped<ICustomerRepository, CustomerRepository>();
	        services.AddTransient<IUnitOfWork, UnitOfWork>();

			services.AddMvc();
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
