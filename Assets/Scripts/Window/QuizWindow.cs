using Libs;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizWindow : MonoBehaviour
{
    [SerializeField]
    private QuestionView _questionView;
    [SerializeField]
    private AnswerView[] _answerViews;
    [SerializeField]
    private Text _answerResultText;
    [SerializeField]
    private Text _gameStatisticsText;
    [SerializeField]
    private Button _nextButton;
    [SerializeField]
    public Slider _progress;

    private QuizLogic _logic = new QuizLogic();

    private int _correct = 0;
    private int _unCorrect = 0;
    private int _allSize = 0;
    private int _lastQuestionsCount = 0;

    public void StartGame(List<IQuestion> questions)
    {
        _logic.StartGame(questions);
        _allSize = questions.Count;
        _lastQuestionsCount = _allSize;
        InitQuestionVisual(_logic.GetCurrentQuestion());
    }

    private void InitQuestionVisual(IQuestion question)
    {
        _questionView.SetQuestion(question.GetQuestionText());

        List<IAnswer> answers = question.GetAnswers();
        answers = Common.ShuffleList(answers);

        for (int i = 0; i < _answerViews.Length; i++)
        {
            _answerViews[i].SetAnswer(answers[i]);
            _answerViews[i].SetOnClickAction(OnAnswerClick);
        }

        _answerResultText.text = "";
        _nextButton.gameObject.SetActive(false);
        SetAnswerButtonsInteractable(true);

        _gameStatisticsText.text = "Осталось: " + _lastQuestionsCount.ToString() + "\nПравильно: " + _correct.ToString() + " не правильно: " + _unCorrect.ToString();
        _progress.value = (_correct + _unCorrect) / (float)_allSize;

    }

    private void OnAnswerClick(IAnswer selectedAnswer)
    {
        if (selectedAnswer.IsCorrect())
        {
            _answerResultText.color = Color.green;
            _answerResultText.text = "Правильно!";
            _correct++;
        }
        else
        {
            _answerResultText.color = Color.red;
            _answerResultText.text = "Неправильно!\nВерный ответ: " + GetCorrectAswer();
            _unCorrect++;
        }
        _logic.CheckAnswer(selectedAnswer);
        _lastQuestionsCount--;

        // Отключаем кнопки вариантов ответа после выбора
        SetAnswerButtonsInteractable(false);


        // Показываем кнопку для следующего вопроса
        _nextButton.gameObject.SetActive(true);
        _nextButton.onClick.RemoveAllListeners();
        _nextButton.onClick.AddListener(NextQuestion);
    }

    private void NextQuestion()
    {
        _logic.SelectNextQuestion();
        if (_logic.IsFinished())
        {
            _nextButton.gameObject.SetActive(false);
            _answerResultText.text = "Игра завершена.";
            _gameStatisticsText.text = "Осталось: " + _lastQuestionsCount.ToString() + " правильно: " + _correct.ToString() + " не правильно: " + _unCorrect.ToString();
            _progress.value = (_correct + _unCorrect) / (float)_allSize;
        }
        else
        {
            InitQuestionVisual(_logic.GetCurrentQuestion());
        }
    }

    private void SetAnswerButtonsInteractable(bool interactable)
    {
        foreach (var btn in _answerViews)
        {
            btn.SetAnswerButtonsInteractable(interactable);
        }
    }

    private string GetCorrectAswer() {
    
        var question = _logic.GetCurrentQuestion();
        if (question == null) {
            return "";
        }
        foreach (var answer in question.GetAnswers()) {
            if (answer.IsCorrect()) {
                return answer.GetAnswerText();
            }
        }
        return "";
    }
}
