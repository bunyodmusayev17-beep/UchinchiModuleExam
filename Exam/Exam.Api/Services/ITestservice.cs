using Exam.Api.Dtos;

namespace Exam.Api.Services
{
    public interface ITestservice
    {

        public Guid CreateQuestion(TestCreateDto questionCreateDto);

        public List<TestGetDto> GetAllQuestions(List<TestGetDto> questions1);

        public TestGetDto? GetQuestionById(Guid questionId);

        public bool RemoveQuestion(Guid questionId);

        public bool UpdateQuestion(Guid questionId, TestUpdateDto newQuestion);

        public TestGetDto GetRandomQuestion();

        public int GetCountOfQuestions();

        

    }
}