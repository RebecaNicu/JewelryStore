// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using JewelryStore.Models;
using JewelryStore.Models.DTO;
using JewelryStore.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace JewelryStore.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;
        //private readonly INotifyService _notifyService;

        public RegisterModel(IRegisterService registerService, ILoginService loginService)
        {
            _registerService = registerService;
            _loginService = loginService;
            //_notifyService = notifyService;

        }

        [BindProperty]
        public RegisterDTO Input { get; set; }
        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

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
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _registerService.RegisterUserAsync(Input);

                    if (result.Id != string.Empty)
                    {
                        await _loginService.LoginByUser(result);

                        //_notifyService.AddNotification("Your account has been created successfully.");
                        return RedirectToAction("", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to register user.");
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
