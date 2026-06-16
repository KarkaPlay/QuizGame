using System;
using QuizGame.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace QuizGame.Core
{
    [CreateAssetMenu(fileName = "QuizEvents", menuName = "QuizGame/Events/QuizEvents")]
    public class QuizEvents : ScriptableObject, IQuizEvents
    {
        public event Action<int> OnQuizSelected;
        public event Action<QuizData> OnSessionStarted;
        public event Action<int, bool> OnAnswerSubmitted;
        public event Action<Question, int> OnQuestionChanged;
        public event Action<int, int> OnSessionCompleted;
        public event Action<bool> OnFadeRequested;

        [SerializeField] private UnityEditor.SceneAsset _menuSceneAsset;
        [SerializeField] private UnityEditor.SceneAsset _levelSceneAsset;
        [HideInInspector] [SerializeField] private string _menuSceneName;
        [HideInInspector] [SerializeField] private string _levelSceneName;

        private void OnValidate()
        {
            _menuSceneName = _menuSceneAsset != null ? _menuSceneAsset.name : "";
            _levelSceneName = _levelSceneAsset != null ? _levelSceneAsset.name : "";
        }

        public void RaiseQuizSelected(int quizIndex)
        {
            OnQuizSelected?.Invoke(quizIndex);
        }

        public void RaiseSessionStarted(QuizData quiz)
        {
            OnSessionStarted?.Invoke(quiz);
        }

        public void RaiseAnswerSubmitted(int answerIndex, bool isCorrect)
        {
            OnAnswerSubmitted?.Invoke(answerIndex, isCorrect);
        }

        public void RaiseQuestionChanged(Question question, int index)
        {
            OnQuestionChanged?.Invoke(question, index);
        }

        public void RaiseSessionCompleted(int score, int total)
        {
            OnSessionCompleted?.Invoke(score, total);
        }

        public void RaiseFadeRequested(bool fadeOut)
        {
            OnFadeRequested?.Invoke(fadeOut);
        }

        public void LoadMenuScene()
        {
            if (!string.IsNullOrEmpty(_menuSceneName))
                SceneManager.LoadScene(_menuSceneName);
            else
                SceneManager.LoadScene("MainMenu");
        }

        public void LoadLevelScene()
        {
            if (!string.IsNullOrEmpty(_levelSceneName))
                SceneManager.LoadScene(_levelSceneName);
            else
                SceneManager.LoadScene("Level");
        }
    }
}