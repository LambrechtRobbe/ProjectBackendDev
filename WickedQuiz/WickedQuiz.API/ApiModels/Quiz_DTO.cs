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

        [Display(Name = "Description")]
        [StringLength(250, MinimumLength = 2, ErrorMessage = "Only 250 characters allowed.")]
        public string Description { get; set; }

        [Display(Name = "Difficulty")]
        [Required(ErrorMessage = "Difficulty required")]
        public string Difficulty { get; set; }

        [Display(Name = "CreatorName")]
        public string CreatorName { get; set; }

        public List<Question_DTO> Questions { get; set; } = new List<Question_DTO>();
    }
}
