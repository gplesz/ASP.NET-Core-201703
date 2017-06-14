using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataTables.AspNet.Core;
using DataTables.AspNet.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FamilyPhotosWithIdentity.Helpers;

namespace FamilyPhotosWithIdentity.Controllers.api
{

    [Produces("application/json")]
    [Route("api/Admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager.ThrowIfNull();
        }

        [HttpGet]
        public IActionResult Get(IDataTablesRequest request)
        {
            var vm = new List<Models.AdminViewModels.IndexViewModel>();
            var roles = roleManager.Roles.ToList();

            var filteredRoles = string.IsNullOrWhiteSpace(request?.Search.Value)
                                    ? roles
                                    : roles.Where(x => x.Name.Contains(request?.Search.Value));
            var rolesPage = filteredRoles.Skip(request?.Start ?? 0).Take(request?.Length ?? 10);
            foreach (var role in rolesPage)
            {
                vm.Add(new Models.AdminViewModels.IndexViewModel { Id = role.Id, Name = role.Name });
            }

            var response = DataTablesResponse.Create(request, roles.Count, vm.Count(), vm);
            return new DataTablesJsonResult(response, true);
        }
    }
}