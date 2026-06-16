using System.Collections.Generic;
using UnityEngine;

namespace QuizGame.Data
{
    [CreateAssetMenu(fileName = "QuizData", menuName = "QuizGame/Data/QuizData")]
    public class QuizData : ScriptableObject
    {
        public string quizName;
        public List<Question> questions;
    }
}
