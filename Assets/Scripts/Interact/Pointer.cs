using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    public static Pointer Instance;

    public Image fill;

    float fillAmount;

    [HideInInspector]
    public bool stopFill;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        stopFill = true;
        StopFill();
        StartCoroutine(Cooldown());
    }

    private void Update()
    {
        if(fill.fillAmount != fillAmount && !stopFill)
            fill.fillAmount = Mathf.MoveTowards(fill.fillAmount, fillAmount, 1);

        if(fill.fillAmount == 1 && !stopFill)
        {
            stopFill = true;
            StopFill();
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2.5f);
        stopFill = false;
    }

    public void Fill(float _fillAmount)
    {
        if (stopFill) return;
        fillAmount = _fillAmount;
    }

    public void StopFill()
    {
        fillAmount = 0;
    }
}
