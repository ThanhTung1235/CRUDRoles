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

        public IActionResult Edit(IdentityRole identityRole)
        {
            if (identityRole.Id == null)
            {
                return NotFound();
            }
            var result = _roleManager.FindByIdAsync(identityRole.Id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(IdentityRole identity)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(identity.Id);
                if (role != null)
                {
                    role.Name = identity.Name;
                    System.Diagnostics.Debug.WriteLine(identity.Name);
                    var result = await _roleManager.UpdateAsync(role);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return Json(e);
            }
        }

        public async Task<ActionResult> Delete(string id, string name)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                role.Name = name;
                var result = await _roleManager.DeleteAsync(role);
            }

            return RedirectToAction(nameof(Index));


        }



    }
}