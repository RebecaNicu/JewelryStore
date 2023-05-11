// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using JewelryStore.Models;
using JewelryStore.Services.Interfaces;
using JewelryStore.Models.DTO;

namespace JewelryStore.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        public LoginDTO Input { get; set; }

        private readonly ILoginService _loginService;

        public LoginModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult OnGet(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                //_notifyService.AddNotification("You are already signed in!");
                return RedirectToAction("", "Home");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _loginService.LoginAsync(Input.Email, Input.Password, Input.RememberMe);

                    if (result.Succeeded)
                    {
                        TempData["TempData"] = "Logarea s-a realizat cu succes!";
                        //_notifyService.AddNotification("You have successfully logged in to your account.");
                        return RedirectToAction("", "Home");
                    }
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError(string.Empty, "Account blocked");
                        //_notifyService.AddNotification("This account is locked. Contact support");
                        return RedirectToPage("./Lockout");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return Page();
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return Page();
        }
    }

}
