using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneService.App.AppData;
using PhoneService.App.Controllers.Inherit;
using PhoneService.App.DTO.Account;
using PhoneService.App.DTO.Users;
using PhoneService.Core.Interfaces;
using PhoneService.Core.Models.Repair;
using PhoneService.Domain.Entities;

namespace PhoneService.App.Controllers
{
    [Authorize(Roles = "appmaster")]
    [Route("[controller]/[action]")]
    public class UsersController : SecureController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IRepairService _repairService;

        public UsersController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IRepairService repairService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _repairService = repairService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(UserAdminForCreateDto userForCreateDto)
        {
            if (ModelState.IsValid)
            {
                var userToCreate = new AppUser()
                {
                    UserName = userForCreateDto.Username,
                    Email = userForCreateDto.Email,
                };

                var result = await _userManager.CreateAsync(userToCreate, userForCreateDto.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description.ToString());
                    }
                }

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(userToCreate, userForCreateDto.RoleName.ToString().ToLower());

                    return RedirectToAction("Index", "Users");
                }

            }

            return View(userForCreateDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ChangePassword(Guid id)
        {
            var user = await _signInManager.UserManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();

            if (user != null)
            {
                var model = new UserAdminForEditDto()
                {
                    UserId = user.Id,
                    Email = user.Email,
                    Username = user.UserName,
                    RoleName = role
                };

                return View(model);
            }

            return BadRequest("User error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(UserAdminForEditDto userForEditDto)
        {
            if (ModelState.IsValid)
            {
                if (userForEditDto.ArePropertiesNotNull())
                {
                    var user = await _signInManager.UserManager.Users.FirstOrDefaultAsync(x => x.Id == userForEditDto.UserId);

                    if (user != null)
                    {
                        var result = await _userManager.ChangePasswordAsync(user, userForEditDto.OldPassword,
                            userForEditDto.Password);

                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description.ToString());
                            }
                        }
                        else
                        {
                            return RedirectToAction("Index", "Users");
                        }
                    }
                }
            }

            return View(userForEditDto);
        }

        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _signInManager.UserManager.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Users");

            }

            return BadRequest("Błąd podczas usuwania Użytkownika");
        }

        [HttpGet]
        public async Task<IActionResult> Statistics(RepairSearchRequest searchStatistics)
        {
            var statistics = await _repairService.GetRepairStatusCountAsync();

            if (searchStatistics.ArePropertiesNotNull())
            {
                statistics = await _repairService.GetRepairStatusCountBySearchAsync(searchStatistics);
            }

            return View(statistics);
        }
    }
}