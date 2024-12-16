using LibraryApplication.Models.DTO.Identity;
using LibraryApplication.Models.Identity;
using LibraryApplication.Service.UserServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryApplication.Controllers
{
    public class LoginController(IUserService userService, SignInManager<AppUser> signInManager) : Controller
    {
		public IActionResult Index()
		{
			if (signInManager.IsSignedIn(User))
			{
				return RedirectToAction("Index", "Jysk");
			}

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Index(LoginDto loginDto)
		{
			var user =await userService.Login(loginDto);

			if (user == null)
			{
				ViewBag.LoginFailed = true;

				return View();
			}

			await signInManager.SignInAsync(user, new AuthenticationProperties()
			{
				IsPersistent = true
			}, CookieAuthenticationDefaults.AuthenticationScheme);
			if (!string.IsNullOrEmpty(loginDto.Redirect)) return Redirect(loginDto.Redirect);

			return RedirectToAction("Index", "Home");
		}

		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();

			return RedirectToAction("Index", "Login");
		}
	}
}
