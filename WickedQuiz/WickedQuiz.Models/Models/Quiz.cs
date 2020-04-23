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

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Required]
        [Range(0, 2)]
        public Difficulty diff { get; set; }

        //Foreign Keys
        public Guid CategoryId { get; set; }
        public string ApplicationUserId { get; set; }

        //Navigation Properties
        public virtual Category Category { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<ScoreTable> ScoreTables { get; set; }

        public enum Difficulty
        {
            easy = 0,
            medium = 1,
            hard = 2
        }
    }
}
