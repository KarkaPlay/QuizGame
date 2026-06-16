using QuizGame.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace QuizGame.Core
{
    public class QuizMenuManager : MonoBehaviour
    {
        [SerializeField] private QuizEvents _events;
        [SerializeField] private QuizCatalog _catalog;
        [SerializeField] private GameObject _buttonPrefab;
        [SerializeField] private Transform _buttonsParent;

        private void Start()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SpawnButtons();
        }

        private void OnEnable()
        {
            _events.OnQuizSelected += HandleQuizSelected;
        }

        private void OnDisable()
        {
            _events.OnQuizSelected -= HandleQuizSelected;
        }

        private void HandleQuizSelected(int quizIndex)
        {
            _catalog.SelectQuiz(quizIndex);
        }

        private void SpawnButtons()
        {
            for (int i = 0; i < _catalog.AllQuizzes.Count; i++)
            {
                var quiz = _catalog.AllQuizzes[i];
                var buttonObj = Instantiate(_buttonPrefab, _buttonsParent);
                buttonObj.GetComponent<QuizGame.UI.QuizButton>().Initialize(quiz.quizName, i, this);
            }
        }

        public void OnQuizSelected(int quizIndex)
        {
            _events.RaiseQuizSelected(quizIndex);
        }

        public void StartGame()
        {
            _events.LoadLevelScene();
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
}
