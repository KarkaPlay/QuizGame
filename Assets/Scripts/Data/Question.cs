using System.Collections.Generic;
using UnityEngine;

namespace QuizGame.Data
{
    [System.Serializable]
    public class Question
    {
        public string questionText;
        public List<string> answers;
        public int correctIndex;
    }
}
