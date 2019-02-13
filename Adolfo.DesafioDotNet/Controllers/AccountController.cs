using Adolfo.AspNetIdentity;
using Adolfo.AspNetIdentity.Models;
using Adolfo.AspNetIdentity.ViewModels;
using Adolfo.DesafioDotNet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adolfo.DesafioDotNet.Controllers
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        private readonly IUser _user;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILoggerFactory loggerFactory,
            IUser user)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
            _user = user;
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<IActionResult> Register([FromForm] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName };
                var hasUser = await _userManager.FindByNameAsync(user.UserName);
                if (hasUser == null)
                {
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        _logger.LogInformation(2, "User created a new account with password.");
                        return Ok(user);
                    }
                    AddErrors(result);
                }
                ModelState.AddModelError("Message", "User already exists.");
                _logger.LogInformation(3, "user already exists on trying to create a new user account.");
            }

            return BadRequest(ModelState);
        }

        [HttpPost("signin")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation(2, "User logged in.");
                    return Ok(new { Message = "User logged in", returnUrl });
                }
                else
                {
                    _logger.LogInformation(3, "Invalid login attempt.");
                    ModelState.AddModelError("Message", "Invalid login attempt.");
                    return BadRequest(ModelState);
                }
            }
            
            return BadRequest(ModelState);
        }

        [HttpGet("logout")]
        public async Task<IActionResult> SignOutAsync()
        {
            if (User?.Identity.IsAuthenticated == true)
            {
                await _signInManager.SignOutAsync();

                _logger.LogInformation(2, "User logged out.");
                return Ok(new { Message = "User logged out." });
            }

            _logger.LogInformation(3, "Invalid login attempt.");
            ModelState.AddModelError("Message", "Invalid login attempt.");
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> UserInfo()
        {
            //var user_id = User.Claims.Where(t => t.Type.Equals("sub")).FirstOrDefault();
            var user = await _userManager.FindByNameAsync(_user.Name);

            return Ok(user);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("Message", error.Description);
            }
        }

    }
}
