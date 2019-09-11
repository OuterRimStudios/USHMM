using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    public static Pointer Instance;

    public Image fill;

    float fillAmount;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(fill.fillAmount != fillAmount)
            fill.fillAmount = Mathf.MoveTowards(fill.fillAmount, fillAmount, 1);
    }

    public void Fill(float _fillAmount)
    {
        fillAmount = _fillAmount;
    }

    public void StopFill()
    {
        fillAmount = 0;
    }
}
