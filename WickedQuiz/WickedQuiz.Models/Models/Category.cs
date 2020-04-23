using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WickedQuiz.Models.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50, ErrorMessage = "Category name is limited to 250 characters in length.")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "Category name is limited to 250 characters in length.")]
        public string Description { get; set; }

        //Navigation Properties
        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
