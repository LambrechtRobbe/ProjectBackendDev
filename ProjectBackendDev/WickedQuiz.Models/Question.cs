using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WickedQuiz.Models
{
    public class Questions
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(100, MinimumLength = 5, ErrorMessage = "Question name is limited to 250 characters in length.")]
        public string Question { get; set; }

        public string? ImgURL { get; set; }

        public Quizes Quizes { get; set; }

        public virtual ICollection<Answers> Answers { get; set; }
    }
}
