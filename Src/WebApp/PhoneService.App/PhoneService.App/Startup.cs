using System;
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
using Microsoft.AspNetCore.Identity;
using PhoneService.Core.Services;
using PhoneService.Domain.Repository;
using PhoneService.Core.Mapping;
using PhoneService.Core.Repository;
using PhoneService.Core.Interfaces;
using PhoneService.Domain.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using PhoneService.App.AppData;
using PhoneService.Infrastructure.Common;
using PhoneService.Core.Services.Healpers;

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
                .AddDbContext<PhoneServiceDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("PhoneServiceDatabase"), 
                    b => b.MigrationsAssembly("PhoneService.App")
                    ));

            services
                .AddIdentity<AppUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<PhoneServiceDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/accesdenied";
                options.LoginPath = "/login";
                options.LogoutPath = "/logout";
            });


            services
                .AddMvc();

            services
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<ICustomerRepository, CustomerRepository>()
                .AddScoped<ISaparePartRepository, SaparePartRepository>()
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IRepairItemRepository, RepairItemRepository>()
                .AddScoped<IRepairRepository, RepairRepository>();


            services
                .AddScoped<ICustomerService, CustomerService>()
                .AddScoped<ISaparePartService, SaparePartService>()
                .AddScoped<IProductService, ProductService>()
                .AddScoped<IRepairService, RepairService>();


            //services.AddSingleton(_ => Configuration);
            services.AddScoped<NullCheckMethod>();
            services.AddScoped<SearchFilterHealpers>();

            //services.AddAutoMapper(
            //    opt => opt.CreateMissingTypeMaps = true,
            //    Assembly.GetEntryAssembly());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            UserManager<AppUser> userManager, RoleManager<IdentityRole<Guid>> roleManager)
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
            app.UseAuthentication();
            app.UseCookiePolicy();

            Mapper.Initialize(x =>
            {
                x.AddProfile<CustomerMappingProfile>();
                x.AddProfile<SaparePartMappingProfile>();
                x.AddProfile<ProductMappingProfile>();
                x.AddProfile<RepairMappingProfile>();
            });

            //Mapper.Configuration.AssertConfigurationIsValid();
            var seed = new SeedData(userManager, roleManager);
            seed.Run().Wait();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
