using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text splashText;
    [TextArea(3, 10)]
    [SerializeField] private string[] startingLines;

    void Start()
    {
        DialogSystem.ShowDialog(this, startingLines, splashText);
    }
}
