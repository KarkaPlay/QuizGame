using System.Collections.Generic;
using QuizGame.Data;
using UnityEngine;

namespace QuizGame.Core
{
    public class QuizCatalog : MonoBehaviour, IQuizCatalog
    {
        [SerializeField] private List<QuizData> _quizzes = new();
        [SerializeField] private QuizEvents _events;

        private int _selectedIndex;

        public IReadOnlyList<QuizData> AllQuizzes => _quizzes;
        public int SelectedQuizIndex => _selectedIndex;

        public void SelectQuiz(int index)
        {
            if (index >= 0 && index < _quizzes.Count)
            {
                _selectedIndex = index;
            }
        }

        public QuizData GetSelectedQuiz()
        {
            if (_selectedIndex >= 0 && _selectedIndex < _quizzes.Count)
            {
                return _quizzes[_selectedIndex];
            }
            return null;
        }
    }
}
