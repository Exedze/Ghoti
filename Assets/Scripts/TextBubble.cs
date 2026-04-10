using System;
using TMPro;
using UnityEngine;

public class TextBubble : MonoBehaviour
{

    public TextMeshPro infoText;
    
    private void OnTriggerEnter(Collider other)
    {
        infoText.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        infoText.enabled = false;
    }

    private void Start()
    {
        infoText.enabled = false;
    }
}


