using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene("Level");
    }
}
