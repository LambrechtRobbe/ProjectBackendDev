using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WickedQuiz.Models
{
    public class ScoreTable
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public int Score { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateFinished { get; set; }

        //Foreign Keys
        public string ClientId { get; set; }
        public Guid? QuizesId { get; set; }

        //Navigation Properties
        public virtual ApplicationUser Client { get; set; }

        public Quizes Quizes { get; set; }
    }
}
