using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WickedQuiz.Models.Models
{
    public class Score
    {
        [Required]
        public int FinalScore { get; set; }
        public int MaxScore { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateFinished { get; set; } = DateTime.Now;
        public string ApplicationUserId { get; set; }
        public Guid QuizId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
