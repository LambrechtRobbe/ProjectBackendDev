using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WickedQuiz.Models
{
    public class Quizes
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(50, MinimumLength = 5, ErrorMessage = "Quiz name is limited to 250 characters in length.")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Range(0, 2)]
        public Difficulty diff { get; set; }

        public virtual Topic Topic { get; set; }

        public virtual ApplicationUser Client { get; set; }

        public virtual ICollection<Questions> Questions { get; set; }

        public enum Difficulty
        {
            easy = 0,
            medium = 1,
            hard = 2
        }
    }
}
