namespace Exam.Api.Dtos
{
    public class TestGetDto
    {
        public string QuestionModel { get; set; }

        public Guid QuestionId { get; set; }

        public string Text { get; set; }

        public string variantA { get; set; }
        public string variantB { get; set; }
        public string variantC { get; set; }

        public string answer { get; set; }
    }
}
