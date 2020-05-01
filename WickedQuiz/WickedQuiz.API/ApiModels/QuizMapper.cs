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
            quiz_DTO.Difficulty = quiz.Difficulty.ToString();
            quiz_DTO.Name = quiz.Name;
            quiz_DTO.Description = quiz.Description;
            List<List<string>> questions = new List<List<string>>();
            foreach (var item in quiz.Questions)
            {
                List<string> question = new List<string>();
                question.Add(item.QuestionName);
                List<string> answers = new List<string>();
                foreach (var itemAnswer in item.Answers)
                {
                    List<string> answer = new List<string>();
                    answer.Add(itemAnswer.AnswerName);
                    if (itemAnswer.Correct == Answer.State.correct)
                    {
                        answer.Add("correct");
                    }
                    // answers.Add(answer);
                }

            }
            return quiz_DTO;
        }
    }
}
