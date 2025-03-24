using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AnswerView : MonoBehaviour
{
    [SerializeField]
    private Button _answerButton;

    [SerializeField]
    private Text _answerLabel;
  
    public void SetAnswer(string answer) {
        _answerLabel.text = answer;
    }

    public void SetOnClickAction(UnityAction onClickAction){
        _answerButton.onClick.RemoveAllListeners();
        _answerButton.onClick.AddListener(onClickAction);
    }

    public void SetAnswerButtonsInteractable(bool interactable) {
        _answerButton.interactable = interactable;
    }
}
