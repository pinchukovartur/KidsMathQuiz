using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
public enum LevelType
{
    Sum = 0,
    Dif = 1,
    SumAndDif
}

[Serializable]
public struct LevelSettings
{
    public int maxValue;
    public LevelType type;
}

public class StartGameWindow : MonoBehaviour
{
    [SerializeField]
    private QuizWindow _quiz;

    [SerializeField]
    private LevelItemBehaviour _levelItemPrefab;

    [SerializeField]
    private GameObject _levelRoot;

    [SerializeField]
    private List<LevelSettings> _settings;

    [SerializeField]
    private GameObject _gameWindow;

    private void Start()
    {
        foreach (var setting in _settings) {
            LevelItemBehaviour levelItem = Instantiate(_levelItemPrefab, _levelRoot.transform);
            levelItem.Init(setting, () => {
                gameObject.SetActive(false);
                _quiz.StartGame(QuestionsManager.Instance.GenerateLevel(setting));
                _gameWindow.SetActive(true);
            });
        }
    }
}