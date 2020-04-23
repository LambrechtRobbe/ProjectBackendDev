using System.Threading.Tasks;
using WickedQuiz.Models.Models;

namespace WickedQuiz.Models.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategoryAsync(Category category);
    }
}