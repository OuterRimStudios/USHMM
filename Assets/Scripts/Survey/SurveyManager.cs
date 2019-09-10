using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveyManager : MonoBehaviour
{
    public static SurveyManager Instance;

    public List<QuestionField> questions;
    public GameObject previous;

    int currentQuestion = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void Next()
    {
        if (currentQuestion == questions.Count - 2)
        {
            Submit();
        }

        questions[currentQuestion].gameObject.SetActive(false);

        if (currentQuestion >= (questions.Count - 1))
            currentQuestion = 0;
        else
            currentQuestion++;

        questions[currentQuestion].gameObject.SetActive(true);
    }

    public void Previous()
    {
        questions[currentQuestion].gameObject.SetActive(false);

        if (currentQuestion == 0)
            currentQuestion = questions.Count - 1;
        else
            currentQuestion--;
        
        questions[currentQuestion].gameObject.SetActive(true);
    }

    public void Submit()
    {
        List<string> answers = new List<string>();

        foreach (QuestionField question in questions)
            answers.Add(question.answer);

        previous.SetActive(false);
        Debug.Log("Survey Submitted");
        //Send to analytics
    }
}
