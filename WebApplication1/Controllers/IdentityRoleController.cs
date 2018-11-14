using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class IdentityRoleController : Controller
    {
        public readonly RoleManager<IdentityRole> _roleManager;

        public IdentityRoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }
        public IActionResult Craete()
        {

            return View();
        }

        public IActionResult Store(IdentityRole identityRole)
        {
            var result = _roleManager.CreateAsync(new IdentityRole(identityRole.Name)).Result.Succeeded;
            if (result)
            {
                return Redirect("Index");
            }

            return StatusCode(500);
        }

        public IActionResult Edit(string Id)
        {
            var exitsRole = _roleManager.FindByIdAsync(Id);
            if (exitsRole == null)
            {
                return NotFound();
            }
            return View(exitsRole);
        }

        public IActionResult Update(IdentityRole identityRole)
        {
            var exitsRole = _roleManager.FindByIdAsync(identityRole.Id);
            if (exitsRole == null)
            {
                return NotFound();
            }
            exitsRole.Result.Name = identityRole.Name;
            _roleManager.UpdateAsync(identityRole);
            return Redirect("Index");
        }

        public IActionResult Delete(string Id)
        {
            var exitsRole = _roleManager.FindByIdAsync(Id);
            if (exitsRole == null)
            {
                return NotFound();
            }
            return Redirect("Index");
        }



    }
}