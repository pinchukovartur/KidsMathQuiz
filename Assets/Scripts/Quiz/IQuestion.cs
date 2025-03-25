using System.Collections.Generic;


public interface IQuestion
{
    string GetQuestionText();
    List<IAnswer> GetAnswers();
}
