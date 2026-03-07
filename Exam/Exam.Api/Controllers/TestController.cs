using Exam.Api.Dtos;
using Exam.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Api.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class TestController : Controller
    {
       private readonly TestService testService;

        public TestController()
        {
            testService = new TestService();
        }

        [HttpGet("create")]
        public Guid Create(TestCreateDto testCreateDto)
        {
            var id = testService.CreateQuestion(testCreateDto);
            return id;
        }

        [HttpGet("get-all")]
        public List<TestGetDto> GetAll()
        {
            return testService.GetAllQuestions();
        }

        [HttpDelete("delete")]
        public bool Delete(Guid id)
        {
            return testService.RemoveQuestion(Guid id); 
        }

        [HttpGet("get-count-question")]
        public int CountOfQuestion()
        {
            return testService.GetCountOfQuestions();
        }

        [HttpPut("update")]
        public bool UpdateQuestion(Guid id, TestUpdateDto testUpdateDto)
        {
            return testService.UpdateQuestion(id, testUpdateDto);
        }

        [HttpGet("get-by-id")]
        public string GetQuestion(Guid id)
        {
            return testService.GetQuestionById(Guid id);
        }


       }
}