using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelItemBehaviour : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _levelName;
    [SerializeField]
    private Button _startButton;

    public void Init(LevelSettings setting, UnityAction onClick)
    {
        string name = "";
        if (setting.type == LevelType.Sum) {
            name += "+";
        }
        else if(setting.type == LevelType.Dif) {
            name += "-";
        }
        else if (setting.type == LevelType.SumAndDif)
        {
            name += "+/-";
        }
        _levelName.text = name + " " + setting.maxValue.ToString();
        _startButton.onClick.RemoveAllListeners();
        _startButton.onClick.AddListener(onClick);
    }

}
