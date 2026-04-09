using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform buttonsParent;

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

        SpawnButtons();
    }

    void SpawnButtons()
    {
        for (int i = 0; i < AllQuizes.Instance.quizes.Count; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonsParent);
            newButton.GetComponent<QuizButton>().Initialize(AllQuizes.Instance.quizes[i].quizName, i, this);
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
