using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WickedQuiz.Models.Models
{
    public class Answer
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Question name is limited to 50 characters in length.")]
        public string AnswerName { get; set; }

        [Required]
        [Range(0, 1)]
        public bool Correct { get; set; }

        public Guid QuestionID { get; set; }

        //Navigation Properties
        public virtual Question Question { get; set; }
    }
}
