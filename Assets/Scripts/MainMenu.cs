using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void SaveQuizChoice(int chosenQuiz)
    {
        AllQuizes.Instance.SelectQuiz(chosenQuiz);
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene("Level");
    }

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
