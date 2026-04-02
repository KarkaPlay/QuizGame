using StarterAssets;
using System.Collections;
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

    public ScreenFader screenFader;

    private bool canAnswer = true;

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
        StartCoroutine(CheckAnswerRoutine(playerAnswer));
    }

    public IEnumerator CheckAnswerRoutine(int playerAnswer)
    {
        Question current = quizData.questions[currentQuestionIndex]; //Вопрос текущий = данныеВикторины.вопросы[номерТекущегоВопроса]

        bool isCorrect = (playerAnswer == current.correctIndex); // онПравильный = (ответИгрока == текущий.номерПравильного)

        // Шаг 1. Блокировать управление

        float oldMoveSpeed = player.GetComponent<ThirdPersonController>().MoveSpeed;
        float oldSprintSpeed = player.GetComponent<ThirdPersonController>().SprintSpeed;

        // float заданнаяСкорость = игрок.Контроллер.заданнаяСкорость

        player.GetComponent<ThirdPersonController>().MoveSpeed = 0;
        player.GetComponent<ThirdPersonController>().SprintSpeed = 0;

        // игрок.Контроллер.заданнаяСкорость = 0

        // Шаг 2. Визуальный фидбэк

        if (isCorrect)
        {
            score++;
            scoreText.text = $"Очки: {score}";
        }
        else
        {
            // Как-то неправильно ответили
        }

        // 3. Fade Out

        yield return StartCoroutine(screenFader.FadeOut()); // Ждем пока экран затемнится



        // 4. Тп игрока и переключение вопроса

        NextQuestion(); // Переключаем вопрос на следующий

        player.SetActive(false);
        player.transform.position = spawnPoint.transform.position; //Игрок.позиция = точкаСпавна.позиция
        player.SetActive(true);

        yield return new WaitForSeconds(1f); // Ждем 1 секунду

        // Fade In

        yield return StartCoroutine(screenFader.FadeIn()); // Ждем пока экран осветляется

        // Вернуть управление
        player.GetComponent<ThirdPersonController>().MoveSpeed = oldMoveSpeed; // игрок.ЗаданнаяСкорость = заданнаяСкорость
        player.GetComponent<ThirdPersonController>().SprintSpeed = oldSprintSpeed;
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

        // номерТекущегоВопроса++;
        // 
        // если(номерТекущегоВопроса < данныеВикторины.вопросы.Количество)
        // {
        //     ПоказатьВопрос();
        // }
        // иначе
        // {
        //     ЗакончитьИгру();
        // }
    }

    void EndGame()
    {
        playerInput.SwitchCurrentActionMap("UI");

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        endgameMenu.SetActive(true);

        player.GetComponent<ThirdPersonController>().enabled = false;

        resultText.text = $"Результат: {score} / {quizData.questions.Count}";
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

