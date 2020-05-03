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
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Answer name is limited to 50 characters in length.")]
        public string AnswerName { get; set; }

        [Required]
        public State Correct { get; set; }

        [Required]
        public Guid QuestionId { get; set; }

        //Navigation Properties
        public virtual Question Question { get; set; }

        public enum State
        {
            incorrect = 0,
            correct = 1
        }
    }
}
