using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WickedQuiz.Web.Data;

namespace WickedQuiz.Models.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly WickedQuizDbContext context;

        public QuizRepository(WickedQuizDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Quizes>> GetAllQuizesAsync(string userId)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Quizes> AddQuizAsync(Quizes quizes)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Quizes> DellQuizAsync(Quizes quizes)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
