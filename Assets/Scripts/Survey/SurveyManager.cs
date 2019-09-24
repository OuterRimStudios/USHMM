using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using OuterRimStudios.Utilities;
using CsvHelper.Configuration.Attributes;

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
        var data = new List<SurveyResults>
        {
            new SurveyResults{ Question1 = questions[0].answer, Question2 = questions[1].answer, Question3 = questions[2].answer, Question4 = questions[3].answer }
        };
        //Add all of the answers to a list that will be sent to the analytics
        //for (int i = 0; i < questions.Count - 1; i++)
            //data.Add(new { Answer = questions[i].answer }); //Analytics.CustomEvent("SurveyResults", new Dictionary<string, object> { { "Question " + (i + 1), questions[i].answer } });

        AnalyticsUtilities.Event("SurveyResults", data);

        Debug.Log("Survey Submitted");
        //Send to analytics
    }
}

public class SurveyResults
{
    [Name("This experience made me feel curious.")]
    public string Question1 { get; set; }
    [Name("This experience made me feel sad.")]
    public string Question2 { get; set; }
    [Name("This experience made me feel compassionate.")]
    public string Question3 { get; set; }
    [Name("This experience made me feel distressed.")]
    public string Question4 { get; set; }
}