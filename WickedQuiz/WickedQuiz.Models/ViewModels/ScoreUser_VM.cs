using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;
using WickedQuiz.Models.Models;

namespace WickedQuiz.Models.ViewModels
{
    public class ScoreUser_VM
    {
        public Guid QId { get; set; }
        public string QName { get; set; }
        public int questioncount { get; set; }
        public int QIndex { get; set; }
        public Question Question { get; set; }
        public IList<Answer> Answers { get; set; }
    }
}
