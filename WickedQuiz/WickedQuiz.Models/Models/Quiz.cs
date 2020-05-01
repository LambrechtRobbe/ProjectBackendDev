using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WickedQuiz.Models.Models
{
    public class Quiz
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50, ErrorMessage = "Quiz name is limited to 250 characters in length.")]
        public string Name { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Quiz name is limited to 250 characters in length.")]
        public string Description { get; set; }

        public Difficulties Difficulty { get; set; }

        [Required]
        [Range(0, 10)]
        public int QuestionCount { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        //Foreign Keys
        public string ApplicationUserId { get; set; }

        //Navigation Properties
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual IList<Question> Questions { get; set; }
        public virtual IList<Score> ScoreTables { get; set; }

        public enum Difficulties
        {
            easy = 0,
            medium = 1,
            hard = 2
        }
    }
}
