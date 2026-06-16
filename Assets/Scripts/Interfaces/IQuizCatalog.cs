using System.Collections.Generic;
using QuizGame.Data;

namespace QuizGame.Core
{
    public interface IQuizCatalog
    {
        IReadOnlyList<QuizData> AllQuizzes { get; }
        int SelectedQuizIndex { get; }
        void SelectQuiz(int index);
        QuizData GetSelectedQuiz();
    }
}
