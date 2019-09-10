using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    public Color selectedColor;

    Image image;
    Color originalColor;
    public TextMeshProUGUI text { get; private set; }

    private void Start()
    {
        image = GetComponent<Image>();
        originalColor = image.color;
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Selected()
    {
        image.color = selectedColor;
    }

    public void DeSelected()
    {
        image.color = originalColor;
    }
}
