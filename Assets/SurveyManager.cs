using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveyManager : MonoBehaviour
{
    public List<QuestionField> questions;
    public GameObject next;
    public GameObject submit;

    int currentQuestion = 0;

    public void Next()
    {
        questions[currentQuestion].gameObject.SetActive(false);

        if (currentQuestion >= (questions.Count - 1))
            currentQuestion = 0;
        else
            currentQuestion++;

        questions[currentQuestion].gameObject.SetActive(true);

        if (currentQuestion == questions.Count - 1)
        {
            next.SetActive(false);
            submit.SetActive(true);
        }
        else if(!next.activeInHierarchy)
        {
            submit.SetActive(false);
            next.SetActive(true);
        }
    }

    public void Previous()
    {
        questions[currentQuestion].gameObject.SetActive(false);

        if (currentQuestion == 0)
            currentQuestion = questions.Count - 1;
        else
            currentQuestion--;
        
        questions[currentQuestion].gameObject.SetActive(true);

        if (currentQuestion == questions.Count - 1)
        {
            next.SetActive(false);
            submit.SetActive(true);
        }
        else if (!next.activeInHierarchy)
        {
            submit.SetActive(false);
            next.SetActive(true);
        }
    }

    public void Submit()
    {
        List<string> answers = new List<string>();

        foreach (QuestionField question in questions)
            answers.Add(question.answer);

        Debug.Log("Survey Submitted");
        gameObject.SetActive(false);
        //Send to analytics
    }
}
