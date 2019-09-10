using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerField : MonoBehaviour
{
    public List<Answer> answers;

    QuestionField questionField;

    private void Start()
    {
        questionField = GetComponentInParent<QuestionField>();
    }

    public void Selected(Answer _answer)
    {
        foreach (Answer answer in answers)
            answer.DeSelected();

        _answer.Selected();
        questionField.UpdateAnswer(_answer.text.text);
    }
}
