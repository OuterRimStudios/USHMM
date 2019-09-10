using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionField : MonoBehaviour
{
    public string answer;

    public void UpdateAnswer(string _answer)
    {
        answer = _answer;
    }
}
