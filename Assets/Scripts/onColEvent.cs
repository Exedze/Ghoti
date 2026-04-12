using UnityEngine;

using UnityEngine.Events;
public class onColEvent : MonoBehaviour
{
    [Tooltip("When you press the escape button")] public UnityEvent OnTrigger;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        OnTrigger.Invoke();
    }
}
