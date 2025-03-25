using UnityEngine;

public class StartGameWindow : MonoBehaviour
{
    [SerializeField]
    QuizWindow _quiz;

    public void StartGame()
    {
        _quiz.StartGame(QuestionsManager.Instance.GetFirstLevelQuestions());
    }

    public void StartGame2()
    {
        _quiz.StartGame(QuestionsManager.Instance.GetSecondLevelQuestions());
    }
}