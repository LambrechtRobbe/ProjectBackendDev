using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WickedQuiz.API.ApiModels
{
    public class Quiz_DTO
    {
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "QuizName")]
        public string Name { get; set; }

        [StringLength(250, MinimumLength = 2, ErrorMessage = "Only 250 characters allowed.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Difficulty required")]
        public string Difficulty { get; set; }

        public List<string> Questions { get; set; } = new List<string>();
    }
}
