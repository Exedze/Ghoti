using UnityEngine;

public class biteTargets : MonoBehaviour
{
    [SerializeField] private Gillbert gilbert;
    private void OnTriggerEnter2D(Collider2D col)
    {
        gilbert.food.Add(col.gameObject);
        Debug.Log("bitein");
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("biteout");
        gilbert.food.Remove(col.gameObject);
    }
}
