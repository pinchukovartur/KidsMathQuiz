using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AnswerView : MonoBehaviour
{
    [SerializeField]
    private Button _answerButton;

    [SerializeField]
    private Text _answerLabel;

    private IAnswer _currentAnswer;

    public void SetAnswer(IAnswer answer)
    {
        _currentAnswer = answer;
        _answerLabel.text = _currentAnswer.GetAnswerText();
    }

    public void SetOnClickAction(UnityAction<IAnswer> onClickAction)
    {
        _answerButton.onClick.RemoveAllListeners();
        _answerButton.onClick.AddListener(() => { onClickAction?.Invoke(_currentAnswer); });
    }

    public void SetAnswerButtonsInteractable(bool interactable)
    {
        _answerButton.interactable = interactable;
    }
}
