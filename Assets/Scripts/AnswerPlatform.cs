using UnityEngine;

public class AnswerPlatform : MonoBehaviour
{
    public int answerIndex;

    public QuizManager quizManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            quizManager.CheckAnswer(answerIndex);
        }
    }
}
