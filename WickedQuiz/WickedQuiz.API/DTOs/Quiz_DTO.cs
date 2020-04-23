using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WickedQuiz.API.DTOs
{
    public class Quiz_DTO
    {
        [Required]
        [StringLength(50, ErrorMessage = "Quiz name is limited to 250 characters in length.")]
        public string Name { get; set; }

        [Required]
        [Range(0, 2)]
        public Difficulty diff { get; set; }

        //Foreign Keys
        public string Category { get; set; }
        public string ApplicationUser { get; set; }

        public List<string> Questions { get; set; } = new List<string>();

        public enum Difficulty
        {
            easy = 0,
            medium = 1,
            hard = 2
        }
    }
}
