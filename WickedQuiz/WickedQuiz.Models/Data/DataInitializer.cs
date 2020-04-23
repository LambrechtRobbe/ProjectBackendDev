using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WickedQuiz.Models.Models;
using WickedQuiz.Models.Repositories;

namespace WickedQuiz.Models.Data
{
    public class DataInitializer : IDataInitializer
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IQuizRepository _quizRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly UserManager<ApplicationUser> _userMgr;

        public DataInitializer(ICategoryRepository categoryRepository, IQuizRepository quizRepository, IQuestionRepository questionRepository, IAnswerRepository answerRepository, UserManager<ApplicationUser> userMgr)
        {
            this._categoryRepository = categoryRepository;
            this._quizRepository = quizRepository;
            this._questionRepository = questionRepository;
            this._answerRepository = answerRepository;
            this._userMgr = userMgr;
        }

        public async Task AddStuff()
        {
            ApplicationUser user = await _userMgr.FindByNameAsync("Docent@MCT");

            Category category = new Category() { Name = "General Konobi", Description = "backend Kenobi" };
            await _categoryRepository.AddCategoryAsync(category);

            List<Answer> answersq1 = new List<Answer>();
            Answer ans1q1 = new Answer() { AnswerName = "Broken Glass", Correct = false };
            Answer ans2q1 = new Answer() { AnswerName = "Balls", Correct = false };
            Answer ans3q1 = new Answer() { AnswerName = "The Moon", Correct = false };
            Answer ans4q1 = new Answer() { AnswerName = "A Tight Rope", Correct = true };
            answersq1.Add(ans1q1);
            answersq1.Add(ans2q1);
            answersq1.Add(ans3q1);
            answersq1.Add(ans4q1);
            foreach (var data in answersq1)
            {
                await _answerRepository.AddAnswerAsync(data);
            }

            List<Question> questions = new List<Question>();
            Question question1 = new Question() { QuestionName = "What does a funambulist walk on?", ImgURL = "https://images.com", Answers = answersq1 };
            questions.Add(question1);
            foreach (var data in questions)
            {
                await _questionRepository.AddQuestionAsync(data);
            }

            Quiz quiz = new Quiz() { Name = "TestQuiz", diff = 0, CategoryId = category.Id, ApplicationUserId = user.Id, Questions = questions }; //, ApplicationUserId = user.Id.ToString()
            await _quizRepository.AddQuizAsync(quiz);
        }
    }
}
