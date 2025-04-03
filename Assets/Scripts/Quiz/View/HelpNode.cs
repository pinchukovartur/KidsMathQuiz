using UnityEngine;
using UnityEngine.UI;

public class HelpNode : MonoBehaviour
{
    [SerializeField]
    private GameObject _holeNode;

    [SerializeField]
    private Image _helperImage;


    public void SetActiveHole(bool value) {
        if (_holeNode) {
            _holeNode.SetActive(value);
        }
    }

    public void SetHelperColor(Color color) {
        if (_helperImage) {
            _helperImage.color = color;
        }
    }
}
