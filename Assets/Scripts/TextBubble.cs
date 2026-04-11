using System;
using TMPro;
using UnityEngine;

public class TextBubble : MonoBehaviour
{

    public TextMeshProUGUI infoText;
    public SpriteRenderer spriteToShow;
    public GameObject collEnd;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        infoText.enabled = true;
        if (spriteToShow != null)
        {
            spriteToShow.enabled = true;
            
        }
        collEnd.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        infoText.enabled = false;
        
    }

    private void Start()
    {
        infoText.enabled = false;
        if (spriteToShow != null)
        {
            spriteToShow.enabled = false;
        }
        collEnd.SetActive(false);
    }
}


