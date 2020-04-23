using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WickedQuiz.Models.Models;
using WickedQuiz.Web.ViewModels;

namespace WickedQuiz.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleMgr;
        private readonly UserManager<ApplicationUser> _userMgr;

        public AdminController(RoleManager<IdentityRole> roleMgr, UserManager<ApplicationUser> userMgr)
        {
            this._roleMgr = roleMgr;
            this._userMgr = userMgr;
        }

        // GET: roles/users
        public ActionResult IndexUsers()
        {
            var result = _userMgr.Users;
            return View(result);//De view ontvangt een @model IEnumerable<ApplicationUser>
        }

        public ActionResult IndexRoles()
        {
            var result = _roleMgr.Roles;
            return View(result);//De view ontvangt een @model IEnumerable<IdentityRole>
        }

        // GET: Admin/Create
        [HttpGet] 
        public IActionResult CreateRole() => View();

        [HttpPost]
        public async Task<IActionResult> CreateRole(AddRole_VM addRoleVM)
        {
            if (!ModelState.IsValid) return View(addRoleVM); 
            var role = new IdentityRole { Name = addRoleVM.RoleName };

            IdentityResult result = await _roleMgr.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("IndexRoles", _roleMgr.Roles);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("CreateRole");
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddRoleToUser(string userId)
        {
            ApplicationUser user = new ApplicationUser();

            //Op basis van het userId halt de _userManager de volledige user op    
            if (!String.IsNullOrEmpty(userId))
            {
                user = await _userMgr.FindByIdAsync(userId);
            }

            if (user == null) return RedirectToAction("IndexRoles", _roleMgr.Roles);

            //Reeds toegekende rollen    
            var assignRolesToUserVM = new RolesForUser_VM()
            {
                AssignedRoles = await _userMgr.GetRolesAsync(user),
                UnAssignedRoles = new List<string>(),
                User = user,
                UserId = userId
            };

            //Nog niet toegekende rollen    
            foreach (var identityRole in _roleMgr.Roles)
            {
                if (!assignRolesToUserVM.AssignedRoles.Contains(identityRole.ToString()))
                {
                    assignRolesToUserVM.UnAssignedRoles.Add(identityRole.Name);
                }
            }

            return View(assignRolesToUserVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToRole(RolesForUser_VM rolesForUserVM)
        {
            var user = await _userMgr.FindByIdAsync(rolesForUserVM.UserId);
            var role = await _roleMgr.FindByNameAsync(rolesForUserVM.RoleId);

            var result = await _userMgr.AddToRoleAsync(user, role.Name);
            var assignRolesToUserVM = new RolesForUser_VM()
            {
                AssignedRoles = await _userMgr.GetRolesAsync(user),
                UnAssignedRoles = new List<string>(),
                User = user,
                UserId = rolesForUserVM.UserId
            };
            if (result.Succeeded)
            {
                return RedirectToAction("AddRoleToUser", assignRolesToUserVM);
            }

            return View(rolesForUserVM);
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}