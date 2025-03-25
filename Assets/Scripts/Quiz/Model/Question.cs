using System.Collections.Generic;

public class Question : IQuestion
{
    private string _question;
    private List<IAnswer> _asnwers = new List<IAnswer>(4);

    public Question(string question, List<IAnswer> asnwers)
    {
        _question = question;
        _asnwers = asnwers;
    }

    List<IAnswer> IQuestion.GetAnswers()
    {
        return _asnwers;
    }

    string IQuestion.GetQuestionText()
    {
        return _question;
    }
}
