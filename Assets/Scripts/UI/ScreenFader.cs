using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace QuizGame.UI
{
    public class ScreenFader : MonoBehaviour
    {
        [SerializeField] private Image _fadeImage;
        [SerializeField] private float _fadeDuration = 0.5f;

        public float FadeDuration => _fadeDuration;

        public IEnumerator FadeOut()
        {
            float timer = 0f;

            while (timer < _fadeDuration)
            {
                timer += Time.deltaTime;
                float alpha = timer / _fadeDuration;
                _fadeImage.color = new Color(0, 0, 0, alpha);
                yield return null;
            }

            _fadeImage.color = new Color(0, 0, 0, 1f);
        }

        public IEnumerator FadeIn()
        {
            float timer = 0f;

            while (timer < _fadeDuration)
            {
                timer += Time.deltaTime;
                float alpha = 1f - (timer / _fadeDuration);
                _fadeImage.color = new Color(0, 0, 0, alpha);
                yield return null;
            }

            _fadeImage.color = new Color(0, 0, 0, 0f);
        }

        public void SetFullBlack()
        {
            _fadeImage.color = new Color(0, 0, 0, 1f);
        }

        public void SetFullyVisible()
        {
            _fadeImage.color = new Color(0, 0, 0, 0f);
        }
    }
}