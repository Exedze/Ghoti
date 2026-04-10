using UnityEngine;
using UnityEngine.InputSystem;

public class Gillbert : MonoBehaviour
{
    [SerializeField] private float speed=600f;
    private Vector2 playerMoveTrack = new Vector2();
    private float velocity;
    [SerializeField] private Rigidbody2D body;
   private bool speedMod=true;
    [SerializeField] private float brakingForce = 0.2f;
    [SerializeField] private float gravityStrength=0.05f;
  

    // Update is called once per frame
    void Update()
    {
        //transform.up = (Vector2) Vector3.Slerp(transform.up, playerMoveTrack, 2 * Time.deltaTime);

        if (speedMod)
        {
            transform.up = (Vector2) Vector3.Slerp(transform.up, playerMoveTrack, 2 * Time.deltaTime);
            velocity += playerMoveTrack.magnitude * Time.deltaTime;
            velocity -= velocity * brakingForce * Time.deltaTime;
        }
        else
        {
            transform.up = new Vector2(transform.up.x, body.linearVelocity.y+playerMoveTrack.y);
        }

    transform.position+=transform.up*Time.deltaTime*velocity*speed;
    }

    private void OnMove(InputValue value)
    {
        playerMoveTrack = value.Get<Vector2>();
        
    }

    public void enterWater()
    {
        speedMod = true;
        body.gravityScale = 0;
        Debug.Log(body.linearVelocity);
        
        body.linearVelocity = Vector2.zero;
    }

    public void exitWater()
    {
        speedMod = false;
        body.gravityScale = gravityStrength;
    }
}
