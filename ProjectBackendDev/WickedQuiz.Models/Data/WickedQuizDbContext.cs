using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WickedQuiz.Models;

namespace WickedQuiz.Web.Data
{
    public class WickedQuizDbContext : IdentityDbContext<IdentityUser>
    {
        public WickedQuizDbContext(DbContextOptions<WickedQuizDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Quizes> Quizes { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<ScoreTable> ScoreTables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //must voor identity
        }
    }
}
