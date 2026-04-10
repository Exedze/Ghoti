using UnityEngine;
using UnityEngine.InputSystem;

public class Gillbert : MonoBehaviour
{
    [SerializeField] private float speed=600f;
    private Vector2 playerMoveTrack = new Vector2();
    private float velocity;
    [SerializeField] private Rigidbody2D body;
   private float speedMod=1;
    [SerializeField] private float brakingForce = 0.2f;
    [SerializeField] private float gravityStrength=0.05f;
  

    // Update is called once per frame
    void Update()
    {
        transform.up = (Vector2)Vector3.Slerp(transform.up, playerMoveTrack, 2*Time.deltaTime);
        
        velocity+=playerMoveTrack.magnitude*speedMod*Time.deltaTime;
        velocity -=velocity*brakingForce*Time.deltaTime*speedMod;
        
        transform.position+=transform.up*Time.deltaTime*velocity*speed;
    }

    private void OnMove(InputValue value)
    {
        playerMoveTrack = value.Get<Vector2>();
        
    }

    public void enterWater()
    {
        speedMod = 1;
        body.gravityScale = 0;
        
    }

    public void exitWater()
    {
        speedMod = 0;
        body.gravityScale = gravityStrength;
    }
}
