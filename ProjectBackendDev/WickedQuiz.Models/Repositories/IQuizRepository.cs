using System.Collections.Generic;
using System.Threading.Tasks;

namespace WickedQuiz.Models.Repositories
{
    public interface IQuizRepository
    {
        Task<Quizes> AddQuizAsync(Quizes quizes);
        Task<Quizes> DellQuizAsync(Quizes quizes);
        Task<IEnumerable<Quizes>> GetAllQuizesAsync(string userId);
    }
}