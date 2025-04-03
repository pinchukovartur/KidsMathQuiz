using UnityEngine;

public class QuestionHelper : MonoBehaviour
{

    [SerializeField]
    private HelpNode _helpNodePrefab;

    [SerializeField]
    public Transform _hintParent;

    public void SpawnHelp(string question)
    {

        // Очистка предыдущих подсказок
        foreach (Transform child in _hintParent)
        {
            Destroy(child.gameObject);
        }

        // Пример вопроса: "2 + 3" или "5 - 3"
        string[] parts = question.Split(' ');
        int first = int.Parse(parts[0]);
        string op = parts[1];
        int second = int.Parse(parts[2]);

        if (op == "+")
        {
            CreateSquares(first, Color.green, false);
            CreateSquares(second, Color.cyan, false);
        }
        else if (op == "-")
        {
            CreateSquares(first - second, Color.green, false); // обычные квадраты
            CreateSquares(second, Color.red, true); // "пустые" квадраты
        }

    }

    private void CreateSquares(int count, Color color, bool isHollow)
    {
        for (int i = 0; i < count; i++)
        {
            HelpNode square = Instantiate(_helpNodePrefab, _hintParent);
            square.SetActiveHole(isHollow);
            square.SetHelperColor(color);

        }

    }
}
