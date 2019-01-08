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
using System.Security.Policy;
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
using PhoneService.Domain;

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

            services.AddSession(opts =>
            {
                opts.Cookie.Name = ".NetEscapades.Session";
                opts.IdleTimeout = TimeSpan.FromMinutes(5);
            });

            services.AddDistributedMemoryCache();

            services
                .AddMvc();


            
            

            services
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<ICustomerRepository, CustomerRepository>()
                .AddScoped<ISaparePartRepository, SaparePartRepository>()
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IRepairItemRepository, RepairItemRepository>()
                .AddScoped<IEmailSubjectRepository, EmailSubjectRepository>()
                .AddScoped<IEmailTemplateRepository, EmailTemplateRepository>()
                .AddScoped<IRepairRepository, RepairRepository>()
                .AddScoped<IProductSaparePartRepository, ProductSaparePartRepository>();


            services
                .AddScoped<ICustomerService, CustomerService>()
                .AddScoped<ISaparePartService, SaparePartService>()
                .AddScoped<IProductService, ProductService>()
                .AddScoped<IRepairService, RepairService>()
                .AddScoped<IEmailSender, EmailSender>()
                .AddScoped<IEmailService, EmailService>();

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));


            //services.AddSingleton(_ => Configuration);
            services
                .AddScoped<NullCheckMethod>()
                .AddScoped<SearchFilterHealpers>()
                .AddScoped<RepairMappingProfile>()
                .AddScoped<SaparePartMappingProfile>();


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
            //app.UseCookiePolicy();
            app.UseSession();

            Mapper.Initialize(x =>
            {
                x.ForAllMaps((obj, cnfg) => cnfg.ForAllOtherMembers(opt => opt.IgnoreSourceWhenDefault()));
                x.AddProfile<CustomerMappingProfile>();
                x.AddProfile<SaparePartMappingProfile>();
                x.AddProfile<ProductMappingProfile>();
                x.AddProfile<RepairMappingProfile>();
                x.AddProfile<RepairItemMappingProfile>();
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
    public static class Extensions
    {
        public static void IgnoreSourceWhenDefault<TSource, TDestination>(this IMemberConfigurationExpression<TSource, TDestination, object> opt)
        {
            var destinationType = opt.DestinationMember.GetMemberType();
            object defaultValue = destinationType.GetTypeInfo().IsValueType ? Activator.CreateInstance(destinationType) : null;
            opt.Condition((src, dest, srcValue) => !Equals(srcValue, defaultValue));
        }

        public static Type GetMemberType(this MemberInfo memberInfo)
        {
            if (memberInfo is MethodInfo)
                return ((MethodInfo)memberInfo).ReturnType;
            if (memberInfo is PropertyInfo)
                return ((PropertyInfo)memberInfo).PropertyType;
            if (memberInfo is FieldInfo)
                return ((FieldInfo)memberInfo).FieldType;
            return null;
        }
    }
}
