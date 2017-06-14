using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FamilyPhotosWithIdentity.Helpers;
using FamilyPhotosWithIdentity.Models.AdminViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace FamilyPhotosWithIdentity.Controllers
{
    [Authorize("RequireElevatedAdminRights")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager.ThrowIfNull();
        }

        public IActionResult Index()
        {
            var vm = new List<Models.AdminViewModels.IndexViewModel>();
            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView(new CreateRoleViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }

            var status = false;
            var message = "";
            try
            {
                var newRole = new IdentityRole(vm.RoleName);
                var result = await roleManager.CreateAsync(newRole);
                if (result.Succeeded)
                {
                    status = true;
                }
                else
                {
                    message = string.Join(",", result.Errors);
                }
            }
            catch (System.Exception ex)
            {
                message = ex.Message;
            }

            return Json(new { status = status, message=message });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var roleToDelete = await roleManager.FindByIdAsync(id);
            if (roleToDelete!=null)
            {
                var vm = new DeleteRoleViewModel { RoleName = roleToDelete.Name };
                return PartialView(vm);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteRoleViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }

            var status = false;
            var message = "";
            try
            {
                var roleToDelete = await roleManager.FindByIdAsync(vm.Id);
                if (roleToDelete!=null)
                {
                    var result = await roleManager.DeleteAsync(roleToDelete);
                    if (result.Succeeded)
                    {
                        status = true;
                    }
                    else
                    {
                        message = string.Join(",", result.Errors);
                    }
                }
                else
                {
                    message = $"Id ({vm.Id}) not found!";
                }
            }
            catch (System.Exception ex)
            {
                message = ex.Message;
            }

            return Json(new { status = status, message = message });
        }
    }
}