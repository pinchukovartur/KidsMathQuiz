using System;
using System.Collections.Generic;

public class QuizLogic
{

    private List<IQuestion> _questions;
    private IQuestion _currentQuest;

    public event Action<IQuestion> OnUpdateQuestion;
    public event Action<IAnswer> OnCorrectAnswerSelect;
    public event Action<IAnswer> OnUnCorrectAnswerSelect;

    public bool IsFinished()
    {
        return _questions.Count == 0;
    }

    public IQuestion GetCurrentQuestion()
    {
        return _currentQuest;
    }

    public void StartGame(List<IQuestion> questions)
    {
        _questions = questions;
        SelectNextQuestion();
    }

    public void StopGame()
    {
        _questions.Clear();
    }

    public void SelectNextQuestion()
    {
        if (_questions.Count == 0)
        {
            StopGame();
            return;
        }

        int questionIndex = UnityEngine.Random.Range(0, _questions.Count);
        _currentQuest = _questions[questionIndex];
        _questions.Remove(_currentQuest);

    }

    // Проверка выбранного ответа
    public void CheckAnswer(IAnswer selectedAnswer)
    {

        if (selectedAnswer.IsCorrect())
        {
            OnCorrectAnswerSelect?.Invoke(selectedAnswer);
        }
        else
        {
            OnUnCorrectAnswerSelect?.Invoke(selectedAnswer);
        }
    }

}