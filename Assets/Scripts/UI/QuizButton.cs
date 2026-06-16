using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QuizGame.UI
{
    public class QuizButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _buttonText;
        [SerializeField] private Button _button;

        private int _quizIndex;
        private QuizGame.Core.QuizMenuManager _menuManager;

        public void Initialize(string quizName, int quizNumber, QuizGame.Core.QuizMenuManager menu)
        {
            _buttonText.text = quizName;
            _quizIndex = quizNumber;
            _menuManager = menu;

            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(OnClicked);
        }

        private void OnClicked()
        {
            _menuManager.OnQuizSelected(_quizIndex);
            _menuManager.StartGame();
        }
    }
}