using QuizGame.Data;
using UnityEngine;

namespace QuizGame.Core
{
    public class QuizSession : MonoBehaviour, IQuizSession
    {
        [SerializeField] private QuizEvents _events;

        private QuizData _currentQuiz;
        private int _currentIndex;
        private int _score;
        private bool _isActive;

        public QuizData CurrentQuiz => _currentQuiz;
        public int CurrentQuestionIndex => _currentIndex;
        public int Score => _score;
        public bool IsActive => _isActive;

        public void StartSession(QuizData quiz)
        {
            _currentQuiz = quiz;
            _currentIndex = 0;
            _score = 0;
            _isActive = true;

            _events.RaiseSessionStarted(_currentQuiz);
            RaiseCurrentQuestion();
        }

        public void SubmitAnswer(int answerIndex)
        {
            if (!_isActive || _currentQuiz == null) return;

            var current = GetCurrentQuestion();
            bool isCorrect = answerIndex == current.correctIndex;

            if (isCorrect)
            {
                _score++;
            }

            _events.RaiseAnswerSubmitted(answerIndex, isCorrect);
        }

        public Question GetCurrentQuestion()
        {
            if (_currentQuiz == null || _currentIndex >= _currentQuiz.questions.Count)
            {
                return null;
            }
            return _currentQuiz.questions[_currentIndex];
        }

        public void AdvanceToNextQuestion()
        {
            _currentIndex++;

            if (_currentIndex < _currentQuiz.questions.Count)
            {
                RaiseCurrentQuestion();
            }
            else
            {
                Complete();
            }
        }

        public void Complete()
        {
            _isActive = false;
            _events.RaiseSessionCompleted(_score, _currentQuiz.questions.Count);
        }

        private void RaiseCurrentQuestion()
        {
            var question = GetCurrentQuestion();
            _events.RaiseQuestionChanged(question, _currentIndex);
        }
    }
}
