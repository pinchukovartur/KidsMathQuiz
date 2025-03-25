public class Answer : IAnswer
{
    private string _answer;
    private bool _isCorrect;

    public Answer(string answer, bool isCorrect)
    {
        _answer = answer;
        _isCorrect = isCorrect;
    }

    public string GetAnswerText()
    {
        return _answer;
    }

    public bool IsCorrect()
    {
        return _isCorrect;
    }
}
