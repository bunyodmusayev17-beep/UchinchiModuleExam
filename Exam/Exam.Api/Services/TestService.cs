using Exam.Api.Dtos;
using Exam.Api.Entities;
using Exam.Api.Repositories;

namespace Exam.Api.Services;

public class TestService : ITestservice
{
    private readonly TestRepository TestRepositoryy;
    
    public TestService() 
    { 
    TestRepositoryy = new TestRepository(); 

    }
  

    public Guid CreateQuestion(TestCreateDto questionCreateDto)
    {
        var question = new Test()
        {
            QuestionId = Guid.NewGuid(),
            QuestionModel = questionCreateDto.QuestionModel,
            Text = questionCreateDto.Text,
            variantA = questionCreateDto.variantA,
            variantB = questionCreateDto.variantB,
            variantC = questionCreateDto.variantC,
            answer = questionCreateDto.answer


        };
        var questions = TestRepositoryy.GetAllQuestion();

        questions.Add(question);

        TestRepositoryy.SaveAllQuestion(questions);

        return question.QuestionId;

    }

    public List<TestGetDto> GetAllQuestions(List<TestGetDto> questions1)
    {
        var questions = TestRepositoryy.GetAllQuestion();

        TestRepositoryy.SaveAllQuestion(questions);

        return questions1;
    }

    public int GetCountOfQuestions()
    {
        var questions = TestRepositoryy.GetAllQuestion();

        var count = 0;

        foreach (var i in questions)
        {
            if(i != null) count++;
        }
        return count;
    }

    public TestGetDto? GetQuestionById(Guid questionId, TestGetDto i1)
    {
        var questions = TestRepositoryy.GetAllQuestion();

        foreach (var i in questions)
        {
            if(questionId == i.QuestionId)
            {
                return i1;

            } 
            
        }
        return null;
    }

    public TestGetDto GetRandomQuestion()
    {
      Random randomQuestion = new Random();
        var qustions = TestRepositoryy.GetAllQuestion();


        var res = qustions.Random(randomQuestion);
        return res;


    }

 

    public bool RemoveQuestion(Guid questionId)
    {
        var questions = TestRepositoryy.GetAllQuestion();

        foreach(var i in questions)
        {
            if(questionId == i.QuestionId)
            {
                questions.Remove(i);
                return true;
            }


        }
        return false;
    }

  

    public bool UpdateQuestion(Guid questionId, TestUpdateDto newQuestion)
    {
        var questions = TestRepositoryy.GetAllQuestion();

        foreach (var i in questions)
        {
            if (i.QuestionId == questionId)
            {
                i.QuestionModel = newQuestion.QuestionModel;
                i.Text = newQuestion.Text;
                i.variantA = newQuestion.variantA;
                i.variantB = newQuestion.variantB;
                i.variantC = newQuestion.variantC;
                i.answer = newQuestion.answer;
                
                return true;
            }
        }

        return false;

    }
}
