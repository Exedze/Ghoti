using UnityEngine;
using UnityEngine.InputSystem;

public class Gillbert : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 playerMoveTrack = new Vector2();
  

    // Update is called once per frame
    void Update()
    {
        transform.up = playerMoveTrack;
        //transform.position += (Vector3)playerMoveTrack;
        
    }

    private void OnMove(InputValue value)
    {
        playerMoveTrack = value.Get<Vector2>()*Time.deltaTime;
    }
}
