using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionView : MonoBehaviour
{
    [SerializeField]
    private Text _questionLabel;

    public void SetQuestion(string question) {
        _questionLabel.text = question;
    }

    public void Clear() {
        _questionLabel.text = "";
    }
}
