using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveyManager : MonoBehaviour
{
    public static SurveyManager Instance;

    public List<QuestionField> questions;

    int currentQuestion = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void Next()
    {
        bool done = false;
        if (currentQuestion == questions.Count - 2)
        {
            done = true;
            Submit();
        }

        print("Next");
        questions[currentQuestion].gameObject.SetActive(false);

        if (currentQuestion >= (questions.Count - 1))
            currentQuestion = 0;
        else
            currentQuestion++;

        questions[currentQuestion].gameObject.SetActive(true);
    }

    public void Previous()
    {
        print("Back");
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
        
        Debug.Log("Survey Submitted");
        //Send to analytics
    }
}
