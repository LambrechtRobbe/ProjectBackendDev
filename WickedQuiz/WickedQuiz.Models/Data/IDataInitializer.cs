using System.Threading.Tasks;

namespace WickedQuiz.Models.Data
{
    public interface IDataInitializer
    {
        Task AddStuff();
    }
}