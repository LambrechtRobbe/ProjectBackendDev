using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WickedQuiz.Models.Data;
using WickedQuiz.Models.Repositories;

namespace WickedQuiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IDataInitializer _dataInitializer;

        public QuizController(IQuizRepository quizRepository, IDataInitializer dataInitializer)
        {
            this._quizRepository = quizRepository;
            this._dataInitializer = dataInitializer;
            
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            await _dataInitializer.AddStuff();
            var result = await _quizRepository.GetAllQuizzesAsync(); 
            return Ok(result); //returnt HTTP verbs 
        }

        // GET: api/Quiz/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Quiz
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Quiz/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
