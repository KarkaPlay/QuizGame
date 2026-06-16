using System.Collections.Generic;
using UnityEngine;

namespace QuizGame.Core
{
    public enum QuizState
    {
        Idle,
        Playing,
        CheckingAnswer,
        ShowingFeedback,
        Completed
    }

    public enum QuizTrigger
    {
        Start,
        SubmitAnswer,
        NextQuestion,
        Complete
    }

    public class QuizStateMachine : MonoBehaviour
    {
        private QuizState _currentState = QuizState.Idle;
        public QuizState CurrentState => _currentState;

        private readonly Dictionary<QuizState, Dictionary<QuizTrigger, QuizState>> _transitions = new()
        {
            { QuizState.Idle, new Dictionary<QuizTrigger, QuizState>
                {
                    { QuizTrigger.Start, QuizState.Playing }
                }
            },
            { QuizState.Playing, new Dictionary<QuizTrigger, QuizState>
                {
                    { QuizTrigger.SubmitAnswer, QuizState.CheckingAnswer }
                }
            },
            { QuizState.CheckingAnswer, new Dictionary<QuizTrigger, QuizState>
                {
                    { QuizTrigger.NextQuestion, QuizState.Playing },
                    { QuizTrigger.Complete, QuizState.Completed }
                }
            },
            { QuizState.Completed, new Dictionary<QuizTrigger, QuizState>
                {
                    { QuizTrigger.Start, QuizState.Idle }
                }
            }
        };

        public bool Transition(QuizTrigger trigger)
        {
            if (_transitions.TryGetValue(_currentState, out var stateTransitions))
            {
                if (stateTransitions.TryGetValue(trigger, out var nextState))
                {
                    _currentState = nextState;
                    return true;
                }
            }
            return false;
        }

        public void ResetTo(QuizState state)
        {
            _currentState = state;
        }
    }
}
