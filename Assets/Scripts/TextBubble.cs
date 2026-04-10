using System;
using TMPro;
using UnityEngine;

public class TextBubble : MonoBehaviour
{

    public TextMeshProUGUI infoText;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        infoText.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        infoText.enabled = false;
    }

    private void Start()
    {
        infoText.enabled = false;
    }
}


