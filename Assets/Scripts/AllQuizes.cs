using System.Collections.Generic;
using UnityEngine;


public class AllQuizes : MonoBehaviour
{
    public static AllQuizes Instance;

    public List<QuizData> quizes;
    public int chosenQuiz;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SelectQuiz(int index)
    {
        chosenQuiz = index;
    }
}