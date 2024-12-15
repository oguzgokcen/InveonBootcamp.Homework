using LibraryApplication.Helpers;
using LibraryApplication.Models.DTO.Identity;
using LibraryApplication.Service.UserService;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LibraryApplication.Controllers
{
	//[Authorize(Roles = "Admin")]
	public class RoleController(IUserService userService) : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Users()
		{
			return View();
		}

		public async Task<JsonResult> ListUsers(bool isActive)
		{
			var users = await userService.GetAppUsers();
			var data = users.Select(x => new 
			{
			Id = x.Id,
			Email = x.Email,
			FullName = x.UserDetails == null ? x.Email : x.UserDetails.FullName
			}).ToList();
			return Json(data.ToJson());
		}

		public async Task<JsonResult> ListUserRoles(Guid id)
		{
			var roles = await userService.GetUserRoles(id);
			var data = roles.Select(x => new
			{
				UserId = id,
				Id = x.Id,
				Name = x.Name,
			}).ToList();
			return Json(data.ToJson());
		}

		public async Task<JsonResult> AddUser(AddUserDto addUserDto)
		{
			
			var result = await userService.CreateUser(addUserDto);
			if (result.Succeeded)
			{
				return Json(JsonExtensions.ToJsonOk());
			}
			return Json(JsonExtensions.ToJsonError(result.Errors.First().Description));
		}

		public async Task<JsonResult> UpdateUser(UpdateUserDto updateUserDto)
		{
			await userService.UpdateUser(updateUserDto);

			return Json(JsonExtensions.ToJsonOk());
		}

		public async Task<JsonResult> DeleteUser(Guid id)
		{
			var result = await userService.DeleteUser(id);

			return Json(JsonExtensions.ToJsonOk());
		}

		//list of crud operations for role
		
	}
}
