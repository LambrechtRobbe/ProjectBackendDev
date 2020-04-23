using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WickedQuiz.Models.Models;
using WickedQuiz.Web.Data;

namespace WickedQuiz.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly WickedQuizDbContext _context;

        public CategoryRepository(WickedQuizDbContext context)
        {
            this._context = context;
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            try
            {
                var result = _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
                return category;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                return null;
            }
        }
    }
}
