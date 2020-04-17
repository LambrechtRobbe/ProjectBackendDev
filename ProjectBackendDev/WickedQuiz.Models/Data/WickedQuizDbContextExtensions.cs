using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WickedQuiz.Models.Data
{
    public class WickedQuizDbContextExtensions
    {
        public async static Task SeedRoles(RoleManager<IdentityRole> RoleMgr)
        {
            IdentityResult roleResult;
            string[] roleNames = { "Admin", "Student", "Docent" };
            foreach (var roleName in roleNames)
            { //verhinderen dat continue dezelfde rollen worden toegvoegd. 
                var roleExist = await RoleMgr.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleMgr.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        public async static Task SeedUsers(UserManager<ApplicationUser> userMgr)
        {
            //1. Admin aanmaken ---------------------------------------------------
            if (await userMgr.FindByNameAsync("admin@devquiz.be") == null)  //controleer de UserName
            {
                var admin = new ApplicationUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "admin@devquiz.be",
                    UserName = "admin@devquiz.be"
                };

                var userResult = await userMgr.CreateAsync(admin, "Admin@12");
                var roleResult = await userMgr.AddToRoleAsync(admin, "Admin");

                if (!userResult.Succeeded || !roleResult.Succeeded)
                {
                    throw new InvalidOperationException("Failed to build user and roles");
                }
            }

            //2. Docent aanmaken ---------------------------------------------------
            if (await userMgr.FindByNameAsync("docent@devquiz.be") == null)  //controleer de UserName
            {
                var docent = new ApplicationUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "docent@devquiz.be",
                    UserName = "docent@devquiz.be"
                };

                var userResult1 = await userMgr.CreateAsync(docent, "Docent@1");
                var roleResult1 = await userMgr.AddToRoleAsync(docent, "Docent");

                if (!userResult1.Succeeded || !roleResult1.Succeeded)
                {
                    throw new InvalidOperationException("Failed to build user and roles");
                }
            }

            //1. Student aanmaken ---------------------------------------------------
            if (await userMgr.FindByNameAsync("student@devquiz.be") == null)  //controleer de UserName
            {
                var student = new ApplicationUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "student@devquiz.be",
                    UserName = "student@devquiz.be"
                };

                var userResult2 = await userMgr.CreateAsync(student, "Student@1");
                var roleResult2 = await userMgr.AddToRoleAsync(student, "Student");

                if (!userResult2.Succeeded || !roleResult2.Succeeded)
                {
                    throw new InvalidOperationException("Failed to build user and roles");
                }
            }
        }
    }
}
