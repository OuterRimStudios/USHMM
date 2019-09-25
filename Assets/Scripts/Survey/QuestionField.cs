using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionField : MonoBehaviour
{
    public string answer;
    public Animator animator;

    public void UpdateAnswer(string _answer)
    {
        answer = _answer;
    }
    
    public void SetAnimator(bool state)
    {
        animator.SetBool("Inactive", state);
    }
}
