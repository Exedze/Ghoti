using System;
using UnityEngine;

public class WaterChecking : MonoBehaviour
{
    [SerializeField]
    private Gillbert gilbert;

    private int waters = 0;
    private void OnTriggerEnter2D(Collider2D col)
    {
        gilbert.enterWater();
        waters++;
        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("ex");
        waters--;
        if (waters == 0)
        {
            gilbert.exitWater();
        }
    }
}
