using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WickedQuiz.Models
{
    public class ApplicationUser: IdentityUser
    {
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name is limited to 50 characters in length.")]
        public string FirstName { get; set; }

        [StringLength(100, ErrorMessage = "Last name is limited to 100 characters in length.")]
        public string LastName { get; set; }

        [StringLength(250, ErrorMessage = "About is limited to 250 characters in length.")]
        public string About { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateRegistered { get; set; } = DateTime.Now;

        public virtual ICollection<Quizes> Quizes{ get; set; }
        public virtual ICollection<ScoreTable> ScoreTables { get; set; }
    }
}
