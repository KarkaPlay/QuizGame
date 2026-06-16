using QuizGame.Data;

namespace QuizGame.Core
{
    public interface IQuizSession
    {
        QuizData CurrentQuiz { get; }
        int CurrentQuestionIndex { get; }
        int Score { get; }
        bool IsActive { get; }

        void StartSession(QuizData quiz);
        void SubmitAnswer(int answerIndex);
        Question GetCurrentQuestion();
    }
}
