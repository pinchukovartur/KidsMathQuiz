using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuizLogic : MonoBehaviour
{
    [SerializeField]
    public QuestionView questionView;         // Текст для отображения вопроса
    [SerializeField]
    public AnswerView[] answerViews;    // Массив кнопок для вариантов ответов

    [SerializeField]
    public Text _lostQuestsCount;
    [SerializeField]
    public Text feedbackText;         // Текст для обратной связи (правильно/неправильно)
    [SerializeField]
    public Button nextButton;         // Кнопка для перехода к следующему вопросу
    [SerializeField]
    public Button stopButton;         // Кнопка для остановки игры
    [SerializeField]
    public Slider _progress;

    private bool gameActive = false;

    private int _correct = 0;
    private int _unCorrect = 0;
    private int _allSize = 0;

    private List<Question> _questions;

    public void StartGame(List<Question> questions)
    {
        _allSize = questions.Count;
        _questions = questions;
        gameActive = true;
        stopButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(false);
        SetAnswerButtonsInteractable(true);
        GenerateQuestion();

        stopButton.onClick.RemoveAllListeners();
        stopButton.onClick.AddListener(StopGame);
    }

    public void StopGame()
    {
        gameActive = false;
        stopButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
        questionView.Clear();
        feedbackText.text = "Игра остановлена. Нажмите 'Старт', чтобы начать заново.";
        SetAnswerButtonsInteractable(false);
        _progress.value = 0;
    }

    // Генерация нового вопроса
    void GenerateQuestion()
    {
        if (!gameActive) return;
        if (_questions.Count == 0) return;

        feedbackText.text = "";
        
        int questionIndex = Random.Range(0, _questions.Count);
        Question question = _questions[questionIndex];

        questionView.SetQuestion(question.question);
        _questions.Remove(question);

        _lostQuestsCount.text = "Осталось: " + _questions.Count.ToString() + " правильно: " + _correct.ToString() + " не правильно: " + _unCorrect.ToString();

        _progress.value =  (_correct + _unCorrect) / (float)_allSize;
        
        // Подготовка списка вариантов ответов
        //List<int> answers = new List<int>();
        //answers.Add(correctAnswer);



        // Перемешиваем варианты ответов
        //for (int i = 0; i < answers.Count; i++)
        //{
        //    int temp = answers[i];
        //    int randomIndex = Random.Range(i, answers.Count);
        //    answers[i] = answers[randomIndex];
        //    answers[randomIndex] = temp;
        //}

        // Назначаем текст и обработчики для каждой кнопки
        for (int i = 0; i < answerViews.Length; i++)
        {
            //int answer = answers[i];
            var answer = question.asnwers[i];
            answerViews[i].SetAnswer(answer.answer);
            answerViews[i].SetOnClickAction(() => CheckAnswer(answer));
        }
    }

    // Проверка выбранного ответа
    void CheckAnswer(Answer selectedAnswer)
    {
        if (!gameActive) return;

        if (selectedAnswer.isCorrect)
        {
            feedbackText.color = Color.green;
            feedbackText.text = "Правильно!";
            _correct++;
        }
        else
        {
            feedbackText.color = Color.red;
            feedbackText.text = "Неправильно!";
            _unCorrect++;
        }

        // Отключаем кнопки вариантов ответа после выбора
        SetAnswerButtonsInteractable(false);
        // Показываем кнопку для следующего вопроса
        nextButton.gameObject.SetActive(true);
        nextButton.onClick.RemoveAllListeners();
        nextButton.onClick.AddListener(NextQuestion);
    }

    // Переход к следующему вопросу
    void NextQuestion()
    {
        if (!gameActive) return;
        if (_questions.Count == 0) {
            StopGame();
            return;
        }

        SetAnswerButtonsInteractable(true);
        nextButton.gameObject.SetActive(false);
        GenerateQuestion();
    }

    // Включение/отключение кнопок вариантов ответа
    void SetAnswerButtonsInteractable(bool interactable){
        foreach (var btn in answerViews) {
            btn.SetAnswerButtonsInteractable(interactable);
        }
    }
}