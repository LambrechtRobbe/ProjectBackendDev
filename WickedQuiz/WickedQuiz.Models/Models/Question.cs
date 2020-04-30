using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WickedQuiz.Models.Models
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Question name is limited to 250 characters in length.")]
        public string QuestionName { get; set; }

        [NotMapped]
        public string ImageUrl
        {
            get { return $"/images/{this.Id}.jpg"; }
        }

        //Foreign Keys
        public Guid QuizId { get; set; }

        //Navigation Properties
        public virtual Quiz Quiz { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
