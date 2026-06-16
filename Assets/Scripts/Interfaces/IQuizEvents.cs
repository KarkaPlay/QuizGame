using System;
using QuizGame.Data;
using UnityEngine;

namespace QuizGame.Core
{
    public interface IQuizEvents
    {
        void RaiseQuizSelected(int quizIndex);
        void RaiseSessionStarted(QuizData quiz);
        void RaiseAnswerSubmitted(int answerIndex, bool isCorrect);
        void RaiseQuestionChanged(Question question, int index);
        void RaiseSessionCompleted(int score, int total);
        void RaiseFadeRequested(bool fadeOut);

        event Action<int> OnQuizSelected;
        event Action<QuizData> OnSessionStarted;
        event Action<int, bool> OnAnswerSubmitted;
        event Action<Question, int> OnQuestionChanged;
        event Action<int, int> OnSessionCompleted;
        event Action<bool> OnFadeRequested;
    }
}
