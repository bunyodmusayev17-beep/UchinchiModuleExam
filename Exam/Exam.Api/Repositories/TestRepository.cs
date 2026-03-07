using Exam.Api.Entities;
using System.Text.Json;

namespace Exam.Api.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly string FilePath;

        public TestRepository()
        {
            var directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Comments.json");
            if (!File.Exists(FilePath))
            {
                var stream = File.Create(FilePath);
                stream.Close();
            }


        }

        public List<Test>? GetAllQuestion()
        {
            var json = File.ReadAllText(FilePath);
            if (string.IsNullOrEmpty(json))
            {
                return new List<Test>();
            }

            var comments = JsonSerializer.Deserialize<List<Test>>(json);
            return comments;
        }

        public void SaveAllQuestion(List<Test> questions)
        {

            var json = JsonSerializer.Serialize(questions);
            File.WriteAllText(FilePath, json);


        }

    }
}
