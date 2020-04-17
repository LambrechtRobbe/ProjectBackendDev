﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WickedQuiz.Models
{
    public class Answers
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Answer { get; set; }
        public bool Correct { get; set; }
        public Questions Questions { get; set; }
    }
}