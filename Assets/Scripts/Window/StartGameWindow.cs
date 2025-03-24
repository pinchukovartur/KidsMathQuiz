using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameWindow : MonoBehaviour
{
    [SerializeField]
    QuizLogic _logic;

    public void StartGame()
    {
        _logic.StartGame(QuestionsManager.Instance.GetFirstLevelQuestions());
    }

    public void StartGame2()
    {
        _logic.StartGame(QuestionsManager.Instance.GetSecondLevelQuestions());
    }
}