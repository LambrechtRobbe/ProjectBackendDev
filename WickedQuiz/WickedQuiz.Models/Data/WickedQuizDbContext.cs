using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WickedQuiz.Models.Models;

namespace WickedQuiz.Web.Data
{
    public class WickedQuizDbContext : IdentityDbContext<ApplicationUser>
    {
        public WickedQuizDbContext(DbContextOptions<WickedQuizDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Quiz> Quizzes { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //must voor identity 
            //modelBuilder.Entity<Score>().HasKey(s => new { s.ApplicationUserId, s.QuizId });
        }
    }
}
