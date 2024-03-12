// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoRecon.WebUI.Areas.Identity.Pages.Account.Manage
{
    public class PersonalDataModel(
        UserManager<IdentityUser> userManager,
        ILogger<PersonalDataModel> logger) : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            return user == null ? NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.") : Page();
        }
    }
}