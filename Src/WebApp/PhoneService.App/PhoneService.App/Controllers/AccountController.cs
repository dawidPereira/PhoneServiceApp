using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneService.App.Controllers.Inherit;
using PhoneService.App.DTO.Account;
using PhoneService.Domain.Entities;

namespace PhoneService.App.Controllers
{
    public class AccountController : SecureController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Route("/login")]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost("/login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            if (ModelState.IsValid)
            {

                var result = await _signInManager
                    .PasswordSignInAsync(userForLoginDto.Username, userForLoginDto.Password, false,
                        lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Dane logowania są błędne!");
                    return View(userForLoginDto);
                }
            }

            return View(userForLoginDto);
        }

        [Route("/logout")]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();

                return RedirectToActionPermanent("LogoutSuccess", "Account");
            }

            return BadRequest();
        }

        [AllowAnonymous]
        public async Task<IActionResult> LogoutSuccess()
        {
            return View();
        }

        [Authorize(Roles = "appmaster")]
        public async Task<IActionResult> CreateUser()
        {
            return View();
        }

        [Authorize(Roles = "appmaster")]
        [HttpPost("account/createuser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(UserForCreateDto userForCreateDto)
        {
            if (ModelState.IsValid)
            {
                var userToCreate = new AppUser()
                {
                    UserName = userForCreateDto.Username,
                    Email = userForCreateDto.Email,
                };

                var result = await _userManager.CreateAsync(userToCreate, userForCreateDto.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(userToCreate, "user");

                    return RedirectToAction("Index", "Home");
                }

                return BadRequest(ModelState);
            }

            return View(userForCreateDto);
        }
    }
}
