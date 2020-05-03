using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WickedQuiz.Models.Models;

namespace WickedQuiz.API.ApiModels
{
    public static class QuizMapper
    {
        public static Quiz_DTO ConvertTo_DTO(Quiz quiz, ref Quiz_DTO quiz_DTO)
        {
            try
            {
                quiz_DTO.Name = quiz.Name;
                quiz_DTO.Description = quiz.Description;
                quiz_DTO.Difficulty = quiz.Difficulty.ToString();
                quiz_DTO.CreatorName = quiz.ApplicationUser.UserName;
                List<Question_DTO> questionsanswers = new List<Question_DTO>();
                foreach (var item in quiz.Questions)
                {
                    Question_DTO question_DTO = new Question_DTO();
                    question_DTO.QuestionName = item.QuestionName;
                    List<Answer_DTO> listanswers = new List<Answer_DTO>();
                    foreach (var answer in item.Answers)
                    {
                        Answer_DTO answer_DTO = new Answer_DTO();
                        answer_DTO.AnswerName = answer.AnswerName;
                        answer_DTO.Correct = answer.Correct.ToString();
                        listanswers.Add(answer_DTO);
                    }
                    question_DTO.Answers = listanswers;
                    questionsanswers.Add(question_DTO);
                }
                quiz_DTO.Questions = questionsanswers;
                return quiz_DTO;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("foutcode: ", ex);
                return quiz_DTO;
            }
        }
    }
}
