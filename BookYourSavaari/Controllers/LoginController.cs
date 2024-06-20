using BusinessService.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BusinessEntity;

namespace BookYourSavaari.Controllers
{
	public class LoginController : Controller
	{
		private readonly IUserService _userService;

		public LoginController(IUserService userService)
		{
			_userService = userService;
		}
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}


		[HttpPost]

		public IActionResult Login(LoginViewModel loginViewModel)
		{
			var d = _userService.CheckLogin(loginViewModel.Email, loginViewModel.Password, out bool suc);

			//d.RoleName = "Admin";
			if (!suc)
			{
				ViewBag.ErrorMessage = "Invalid UserName and Password";
			}
			else
			{
				var claims = new List<Claim>() {
					new Claim(ClaimTypes.NameIdentifier, Convert.ToString(d.UserId)),
					   new Claim(ClaimTypes.Name,d.Email),
                        //new Claim(ClaimTypes.Role,d.RoleName)

                };

				var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				//Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
				var principal = new ClaimsPrincipal(identity);
				//SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
				HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
				{
					IsPersistent = false,

				});

				return RedirectToAction("Index", "Home");

			}
			return View("Login");
		}
	}
}
