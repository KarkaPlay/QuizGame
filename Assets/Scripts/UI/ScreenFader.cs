using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 0.5f;

    /// <summary>
    /// Затемнение экрана. Непрозрачность черной картинки плавно переходит от 0 к 1
    /// </summary>
    public IEnumerator FadeOut()
    {
        float timer = 0;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = timer / fadeDuration;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 1);
    }

    /// <summary>
    /// Отмена затемнения экрана. Непрозрачность черной картинки плавно переходит от 1 к 0
    /// </summary>
    public IEnumerator FadeIn()
    {
        float timer = 0;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = 1 - (timer / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 0);
    }

}
