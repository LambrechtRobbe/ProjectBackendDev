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

        public async static Task SeedQuiz(UserManager<ApplicationUser> userMgr)
        {
            var docent = await userMgr.FindByNameAsync("docent@devquiz.be");
            Topic topic = new Topic() { Name = "General Knowledge" };
            
            List<Answers> answersq1 = new List<Answers>();
            Answers ans1q1 = new Answers() { Answer = "Broken Glass", Correct = false};
            Answers ans2q1 = new Answers() { Answer = "Balls", Correct = false};
            Answers ans3q1 = new Answers() { Answer = "The Moon", Correct = false};
            Answers ans4q1 = new Answers() { Answer = "A Tight Rope", Correct = true};
            answersq1.Add(ans1q1);
            answersq1.Add(ans2q1);
            answersq1.Add(ans3q1);
            answersq1.Add(ans4q1);
            List<Answers> answersq2 = new List<Answers>();
            Answers ans1q2 = new Answers() { Answer = "Single", Correct = false };
            Answers ans2q2 = new Answers() { Answer = "Secure", Correct = false };
            Answers ans3q2 = new Answers() { Answer = "Solid", Correct = false };
            Answers ans4q2 = new Answers() { Answer = "Subscriber", Correct = true };
            answersq1.Add(ans1q2);
            answersq1.Add(ans2q2);
            answersq1.Add(ans3q2);
            answersq1.Add(ans4q2);
            List<Answers> answersq3 = new List<Answers>();
            Answers ans1q3 = new Answers() { Answer = "A medical procedure", Correct = false };
            Answers ans2q3 = new Answers() { Answer = "A sport", Correct = false };
            Answers ans3q3 = new Answers() { Answer = "A language", Correct = false };
            Answers ans4q3 = new Answers() { Answer = "A dance", Correct = true };
            answersq1.Add(ans1q3);
            answersq1.Add(ans2q3);
            answersq1.Add(ans3q3);
            answersq1.Add(ans4q3);
            List<Answers> answersq4 = new List<Answers>();
            Answers ans1q4 = new Answers() { Answer = "Elul", Correct = false };
            Answers ans2q4 = new Answers() { Answer = "New Year", Correct = false };
            Answers ans3q4 = new Answers() { Answer = "Succoss", Correct = false };
            Answers ans4q4 = new Answers() { Answer = "Rosh Hashanah", Correct = true };
            answersq1.Add(ans1q4);
            answersq1.Add(ans2q4);
            answersq1.Add(ans3q4);
            answersq1.Add(ans4q4);
            List<Answers> answersq5 = new List<Answers>();
            Answers ans1q5 = new Answers() { Answer = "Answer", Correct = false };
            Answers ans2q5 = new Answers() { Answer = "Cause", Correct = false };
            Answers ans3q5 = new Answers() { Answer = "Source", Correct = false };
            Answers ans4q5 = new Answers() { Answer = "Truth", Correct = true };
            answersq1.Add(ans1q5);
            answersq1.Add(ans2q5);
            answersq1.Add(ans3q5);
            answersq1.Add(ans4q5);
            List<Questions> questions = new List<Questions>();
            Questions questions1 = new Questions() { Question = "What does a funambulist walk on?", answers = answersq1 };
            Questions questions2 = new Questions() { Question = "What does the &#039;S&#039; stand for in the abbreviation SIM, as in SIM card?", answers = answersq2};
            Questions questions3 = new Questions() { Question = "What is &quot;dabbing&quot;?", answers = answersq3 };
            Questions questions4 = new Questions() { Question = "What is the name of the Jewish New Year?", answers = answersq4 };
            Questions questions5 = new Questions() { Question = "According to Sherlock Holmes, &quot;If you eliminate the impossible, whatever remains, however improbable, must be the...&quot;", answers = answersq5 };
            questions.Add(questions1);
            questions.Add(questions2);
            questions.Add(questions3);
            questions.Add(questions4);
            questions.Add(questions5);
            Quizes quizes = new Quizes()
            {
                Name = "EasyTestQuiz",
                diff = 0,
                TopicId = topic.Id,
                ClientId = docent.Id,
                Questions = questions
            };
        }
    }
}
