using QuizGame.Data;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace QuizGame.Core
{
    public class QuizGameManager : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private QuizEvents _events;
        [SerializeField] private QuizCatalog _catalog;
        [SerializeField] private QuizSession _session;

        [Header("UI")]
        [SerializeField] private TextMeshProUGUI _questionText;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private GameObject _endgameMenu;
        [SerializeField] private TextMeshProUGUI _resultText;
        [SerializeField] private QuizGame.UI.ScreenFader _screenFader;

        [Header("Player")]
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private PlayerInput _playerInput;

        private int _score;

        private void Awake()
        {
            Application.targetFrameRate = 60;
        }

        private void OnEnable()
        {
            _events.OnSessionStarted += HandleSessionStarted;
            _events.OnQuestionChanged += HandleQuestionChanged;
            _events.OnAnswerSubmitted += HandleAnswerSubmitted;
            _events.OnSessionCompleted += HandleSessionCompleted;
        }

        private void OnDisable()
        {
            _events.OnSessionStarted -= HandleSessionStarted;
            _events.OnQuestionChanged -= HandleQuestionChanged;
            _events.OnAnswerSubmitted -= HandleAnswerSubmitted;
            _events.OnSessionCompleted -= HandleSessionCompleted;
        }

        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            var quiz = _catalog.GetSelectedQuiz();
            if (quiz != null)
            {
                _session.StartSession(quiz);
            }
        }

        private void HandleSessionStarted(QuizData quiz)
        {
            _score = 0;
            UpdateScoreText();
        }

        private void HandleQuestionChanged(QuizGame.Data.Question question, int index)
        {
            if (question == null) return;

            _questionText.text = question.questionText;
        }

        private void HandleAnswerSubmitted(int answerIndex, bool isCorrect)
        {
            if (isCorrect)
            {
                _score++;
                UpdateScoreText();
            }
        }

        private void HandleSessionCompleted(int score, int total)
        {
            _resultText.text = $"Результат: {score} / {total}";
            _endgameMenu.SetActive(true);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        private void UpdateScoreText()
        {
            _scoreText.text = $"Очки: {_score}";
        }

        public void OnAnswerSelected(int answerIndex)
        {
            _session.SubmitAnswer(answerIndex);
        }

        public void OnNextQuestionRequested()
        {
            _session.AdvanceToNextQuestion();
        }

        public void ReturnToMenu()
        {
            _events.LoadMenuScene();
        }

        public Transform SpawnPoint => _spawnPoint;
        public PlayerController PlayerController => _playerController;
        public QuizEvents Events => _events;
    }
}
