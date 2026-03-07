using Exam.Api.Entities;

namespace Exam.Api.Repositories
{
    public interface ITestRepository
    {
        public List<Test>? GetAllQuestion();

        public void SaveAllQuestion(List<Test> questions);
    }
}