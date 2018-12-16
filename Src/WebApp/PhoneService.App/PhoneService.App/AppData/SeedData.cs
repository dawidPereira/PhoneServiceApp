using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using PhoneService.Domain.Entities;
using PhoneService.Persistance;

namespace PhoneService.App.AppData
{
    public class SeedData
    {
        private const string _adminRoleName = "appmaster";
        private string _adminEmail = "radmin@phoneserviceapp.com";
        private string _adminPassword = "SuperSecret1@3";

        private string[] _defaultRoles = new string[] {_adminRoleName, "user"};

        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public async Task Run()
        {
            await Initialize();          
        }

        public SeedData(UserManager<AppUser> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Initialize()
        {
            await EnsureRoles();
            await EnsureDefaultUser();

        }

        protected async Task EnsureRoles()
        {
            foreach (var role in _defaultRoles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole<Guid>(role));
                }
            }
        }

        protected async Task EnsureDefaultUser()
        {
            var adminUsers = await _userManager.GetUsersInRoleAsync(_adminRoleName);

            if (!adminUsers.Any())
            {
                var adminUser = new AppUser()
                {
                    Email = _adminEmail,
                    UserName = _adminEmail
                };

                var result = await _userManager.CreateAsync(adminUser, _adminPassword);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(adminUser, _adminRoleName);
                }
                 

            }
        }
    }
}
