using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class AAAAAAAAAAAAAAAAAAAAAAA : MonoBehaviour
{
    [Tooltip("When you press the escape button")] public UnityEvent OnESCPressed;
    private void OnOpenmenu(InputValue value)
    {
        OnESCPressed.Invoke();
    }
}
