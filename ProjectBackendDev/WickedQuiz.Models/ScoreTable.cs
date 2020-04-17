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

        public virtual ApplicationUser Client { get; set; }

        public Quizes Quizes { get; set; }
    }
}
