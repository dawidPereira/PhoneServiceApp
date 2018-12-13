using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneService.Persistance;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using PhoneService.Domain.Repository.IUnitOfWork;
using PhoneService.Core.Repository.UnitOfWork;
using AutoMapper;
using PhoneService.Core.Services;
using PhoneService.Domain.Repository;
using PhoneService.Core.Mapping;
using PhoneService.Core.Repository;

namespace PhoneService.App
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;

            });

            services
                .AddDbContext<PhoneServiceDbContext>()
                .AddDbContext<PhoneServiceDbContext>(options =>
                    options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PhoneService;Trusted_Connection=True;Application Name=PhoneServiceDatabase;", 
                    b => b.MigrationsAssembly("PhoneService.App")
                    ));

            services
                .AddMvc();

            services
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddTransient<ICustomerRepository, CustomerRepository>()
                .AddTransient<ISaparePartRepository, SaparePartRepository>();

            services
                .AddScoped<ICustomerService, CustomerService>();


            services.AddSingleton(_ => Configuration);

            services.AddAutoMapper(
                opt => opt.CreateMissingTypeMaps = true,
                Assembly.GetEntryAssembly());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            Mapper.Initialize(x =>
            {
                x.AddProfile<CustomerMappingProfile>();
                x.AddProfile<SaparePartMappingProfile>();
            });

            Mapper.Configuration.AssertConfigurationIsValid();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
