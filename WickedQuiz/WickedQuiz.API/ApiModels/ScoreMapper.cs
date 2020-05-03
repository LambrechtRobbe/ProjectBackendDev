using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedQuiz.Models.Models;

namespace WickedQuiz.API.ApiModels
{
    public class ScoreMapper
    {
        public static ScoreTable_DTO ConvertTo_DTO(Score score, ref ScoreTable_DTO score_DTO)
        {
            score_DTO.QuizName = (score_DTO.QuizName is null) ? "" :  score.Quiz.Name;
            score_DTO.ApplicationUser = (score.ApplicationUser is null) ? "" : score.ApplicationUser.UserName;
            score_DTO.FinalScore = score.FinalScore;
            score_DTO.MaxScore = score.MaxScore;
            score_DTO.Datefinished = score.DateFinished;
            return score_DTO;
        }
    }
}
