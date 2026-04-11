using System;
using UnityEngine;
using UnityEngine.Events;
public class SceneLoaderExtra : MonoBehaviour
{
    [Tooltip("When you press the escape button")] public UnityEvent OnESCPressed;
    [Tooltip("When you press the J button")] public UnityEvent OnJPressed;
   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnESCPressed.Invoke();
        if (Input.GetButtonDown("Horizantal"))
            OnJPressed.Invoke();
    }

}