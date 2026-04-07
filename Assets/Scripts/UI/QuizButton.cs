using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizButton : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    public Button button;

    public void Initialize(string quizName, int quizNumber, MainMenu menu)
    {
        buttonText.text = quizName;

        button.onClick.AddListener(() =>
        {
            menu.SaveQuizChoice(quizNumber);
            menu.SwitchScene();
        });
    }
}
