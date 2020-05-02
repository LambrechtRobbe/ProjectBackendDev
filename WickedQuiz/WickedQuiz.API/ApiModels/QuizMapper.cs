using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedQuiz.Models.Models;

namespace WickedQuiz.API.ApiModels
{
    public static class QuizMapper
    {
        public static Quiz_DTO ConvertTo_DTO(Quiz quiz, ref Quiz_DTO quiz_DTO)
        {
            quiz_DTO.Name = quiz.Name;
            quiz_DTO.Description = quiz.Description;
            quiz_DTO.Difficulty = quiz.Difficulty.ToString();
            quiz_DTO.CreatorName = quiz.ApplicationUser.UserName;
            List<string> questions = new List<string>();
            foreach (var item in quiz.Questions)
            {
                questions.Add(item.QuestionName);
                List<string> answers = new List<string>();
                foreach (var answer in item.Answers)
                {
                    answers.Add(answer.AnswerName);
                    if (answer.Correct == Answer.State.correct)
                    {
                        answers.Add("correct");
                    }
                    else
                    {
                        answers.Add("incorrect");
                    }
                }
                questions.AddRange(answers);
            }
            quiz_DTO.Questions = questions;
            return quiz_DTO;
        }
    }
}
