using UnityEngine;

public class AnswerPlatform : MonoBehaviour
{
    public int answerIndex;

    public QuizManager quizManager;

    public GameObject correctVFX;
    public GameObject wrongVFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            quizManager.CheckAnswer(this);
        }
    }

    public void SpawnCorrectVFX()
    {
        Instantiate(correctVFX, transform);
    }

    public void SpawnWrongVFX()
    {
        Instantiate(wrongVFX, transform);
    }
}
