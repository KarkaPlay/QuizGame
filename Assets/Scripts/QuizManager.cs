using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public List<Question> questions;
    public TextMeshProUGUI questionTextField;
    public List<TextMeshProUGUI> answerTextFields;

    public int currentQuestionIndex = 0;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    public GameObject player;
    public GameObject spawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowQuestion();
    }

    void ShowQuestion()
    {
        Question current = questions[currentQuestionIndex];

        questionTextField.text = current.questionText;

        for (int i = 0; i < answerTextFields.Count; i++)
        {
            answerTextFields[i].text = current.answers[i];
        }
    }

    public void CheckAnswer(int playerAnswer)
    {
        Question current = questions[currentQuestionIndex];

        if (playerAnswer == current.correctIndex)
        {
            Debug.Log("Молодец правильно");
            score++;
            scoreText.text = $"Очки: {score}";
        }
        else
        {
            Debug.Log("Не молодец неправильно");
        }

        player.SetActive(false);

        player.transform.position = spawnPoint.transform.position;

        player.SetActive(true);

        NextQuestion();
    }

    void NextQuestion()
    {
        currentQuestionIndex++;

        if (currentQuestionIndex < questions.Count)
        {
            ShowQuestion();
        }
        else
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log($"Викторина окончена! Результат: {score} из {questions.Count}");
    }
}
