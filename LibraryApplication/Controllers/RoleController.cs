using LibraryApplication.Helpers;
using LibraryApplication.Models.DTO.Identity;
using LibraryApplication.Service.UserServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LibraryApplication.Controllers
{
	//[Authorize(Roles = "Admin")]
	public class RoleController(IUserService userService,IRoleService roleService) : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Users()
		{
			return View();
		}

		public async Task<JsonResult> ListUsers()
		{
			var users = await userService.GetAppUsers();
			var data = users.Select(x => new 
			{
			UserId = x.Id,
			Email = x.Email,
			FullName = x.UserDetails == null ? x.Email : x.UserDetails.FullName
			}).ToList();
			return Json(data.ToJson());
		}

		public async Task<JsonResult> AddUser(AddUserDto addUserDto)
		{
			
			var result = await userService.CreateUser(addUserDto);
			if (result.Succeeded)
			{
				return Json(addUserDto.ToJson());
			}
			return Json(JsonExtensions.ToJsonError(result.Errors.First().Description));
		}

		public async Task<JsonResult> UpdateUser(UpdateUserDto updateUserDto)
		{
			await userService.UpdateUser(updateUserDto);

			return Json(JsonExtensions.ToJsonOk());
		}

		public async Task<JsonResult> DeleteUser(Guid UserId)
		{
			var result = await userService.DeleteUser(UserId);

			return Json(JsonExtensions.ToJsonOk());
		}

		//list of crud operations for roles for the spesific user
		public async Task<JsonResult> ListUserRoles(Guid UserId)
		{
			var roles = await roleService.GetUserRoles(UserId);
			var data = roles.Select(x => new
			{
				RoleName = x,
			}).ToList();
			return Json(data.ToJson());
		}

		public async Task<JsonResult> AddRoleToUser(AddRoleDto addRoleDto)
		{
			var result = await roleService.AddRoleToUser(addRoleDto);
			if (result.Succeeded)
			{
				return Json(addRoleDto.ToJson());
			}
			return Json(JsonExtensions.ToJsonError(result.Errors.First().Description));
		}

		public async Task<JsonResult> DeleteRoleFromUser(RemoveRoleFromUserDto removeRoleFromUserDto)
		{
			var result = await roleService.DeleteRoleFromUser(removeRoleFromUserDto);
			if (result.Succeeded)
			{
				return Json(JsonExtensions.ToJsonOk());
			}
			return Json(JsonExtensions.ToJsonError(result.Errors.First().Description));
		}

		public async Task<JsonResult> GetRoles()
		{
			var result = await roleService.GetRoles();
			if(result != null)
			{
				var data = result.Select(x => new
				{
					RoleName = x.Name,
				}).ToList();
				return Json(data.ToJson());
			}
			return Json(JsonExtensions.ToJsonError("Error getting roles"));
		}

		public async Task<JsonResult> AddRole(string RoleName)
		{
			var result = await roleService.AddRole(RoleName);
			if (result.Succeeded)
			{
				return Json(new { RoleName}.ToJson());
			}
			return Json(JsonExtensions.ToJsonError(result.Errors.First().Description));
		}

		public async Task<JsonResult> UpdateRole(UpdateRoleDto updateRoleDto)
		{
			await roleService.UpdateRole(updateRoleDto);
			return Json(updateRoleDto.ToJson());
		}

		public async Task<JsonResult> DeleteRole(string RoleName)
		{
			await roleService.DeleteRole(RoleName);
			return Json(JsonExtensions.ToJsonOk());
		}

	}
}
