using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WickedQuiz.Models
{
    public class Topic
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(25, MinimumLength = 1, ErrorMessage = "Question name is limited to 250 characters in length.")]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Quizes> QuizesId { get; set; }
    }
}
