using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public List<Question> questions;

    public TextMeshProUGUI questionTextField;

    public List<TextMeshProUGUI> answerTextFields;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questionTextField.text = questions[0].questionText;

        for (int i = 0; i < answerTextFields.Count; i++)
        {
            Debug.Log($"В поле номер {i} записан текст ответа номер {i} ({questions[0].answers[i]}) из вопроса номер {0}");

            answerTextFields[i].text = questions[0].answers[i];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
