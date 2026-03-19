using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public QuizData quizData;
    public TextMeshProUGUI questionTextField;
    public List<TextMeshProUGUI> answerTextFields;

    public int currentQuestionIndex = 0;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    public GameObject player;
    public GameObject spawnPoint;

    public PlayerInput playerInput;
    public GameObject endgameMenu;
    public TextMeshProUGUI resultText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        quizData = AllQuizes.Instance.quizes[AllQuizes.Instance.chosenQuiz];

        ShowQuestion();
    }

    void ShowQuestion()
    {
        Question current = quizData.questions[currentQuestionIndex];

        questionTextField.text = current.questionText;

        for (int i = 0; i < answerTextFields.Count; i++)
        {
            answerTextFields[i].text = current.answers[i];
        }
    }

    public void CheckAnswer(int playerAnswer)
    {
        Question current = quizData.questions[currentQuestionIndex];

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

        if (currentQuestionIndex < quizData.questions.Count)
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
        playerInput.SwitchCurrentActionMap("UI");

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        endgameMenu.SetActive(true);

        resultText.text = $"Результат: {score} / {quizData.questions.Count}";
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
