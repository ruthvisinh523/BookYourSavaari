using BusinessEntity;
using BusinessService.Concreate;
using BusinessService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookYourSavaari.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        public IActionResult GetData()
        {
            var d = userService.GetUsers();
            return Json(new { data = d });
        }

		//public IActionResult AddEditUser(int? id )
		//{
		//    if (id.HasValue)
		//    {

		//        ViewData["Form Title"] = "Edit user";

		//        string d1 = Convert.ToString(ViewData["Form Title"]);

		//        return View(userService.GetUsers(id.Value));
		//    }

		//    ViewData["FormTitle"] = "Add User";
		//    return View();


		//}
		//[HttpPost]
		//public IActionResult AddEditUser(UserViewModel user)
		//{


		//    TempData["message"] = user.UserId > 0 ? "User updated sucessfully" : "User save  sucessfully!";

		//    var p = userService.AddEditUser(user);
		//    return RedirectToAction("AddEditUser");
		//}

		public IActionResult Registration()
		{

			return View("Registration");

		}

		[HttpPost]
		public IActionResult Registration(UserViewModel UserViewModel)
		{
			userService.Registeration(UserViewModel);
			return RedirectToAction("Index", "Home");

		}

	


	}
}
