﻿using Microsoft.AspNetCore.Mvc;
using BookStoreMvc.Models.DTO;
using BookStoreMvc.Repositories.Abstract;

namespace BookStoreMvc.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private IUserAuthenticationService authService;
        public UserAuthenticationController(IUserAuthenticationService authService)
        {
            this.authService = authService;
        }
        /* create a user with admin rights, after that comment this method because we need only
          one user in this application If you need other users ,you can implement this registration method with view
         */

        public async Task<IActionResult> Register()
        {
            var model = new RegistrationModel
            {
                Email = "admin@gmail.com",
                Username = "Cat",
                Name = "CatBookLover",
                Password = "Cat123.",
                PasswordConfirm = "Cat123.",
                Role = "Admin"
            };
            // if you want to register with user , Change Role="User"
            var result = await authService.RegisterAsync(model);
            return Ok(result.Message);
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await authService.LoginAsync(model);
            if (result.StatusCode == 1)
                return RedirectToAction("Index", "Home");
            else
            {
                TempData["msg"] = "Could not logged in..";
                return RedirectToAction(nameof(Login));
            }
        }

        public async Task<IActionResult> Logout()
        {
            await authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

    }
}
