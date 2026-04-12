using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gillbert : MonoBehaviour
{
    [SerializeField] private float speed=6f;
    private Vector2 playerMoveTrack = new Vector2();
    private float velocity=0;
    [SerializeField] private Rigidbody2D body;
   private bool speedMod=true;
    //[SerializeField] private float brakingForce = 0.2f;
    [SerializeField] private float gravityStrength=0.05f;
    [SerializeField] private float boostForce=2;
    private float sb1 = 0;
    private float sb2 = 0;
    private float movementMulti=1;
    private Vector3 prevcord = Vector3.zero;
    private Vector3 delta = Vector3.zero;
    [SerializeField] private float leapForce = 1;
    private Vector2 LeapVec=Vector2.zero;
    [HideInInspector] public List<GameObject> food = new List<GameObject>();
    private Vector3 respawn=Vector3.zero;
    [SerializeField] private float TimeToDrown = 10;
    [SerializeField] private float FlopBreath = 2;
    private float gurglegurgle = 0;

    [SerializeField]
    private AudioSource splash;
    [SerializeField]
    private AudioSource eat;


    // Update is called once per frame
    void Update()
    {
delta = transform.position - prevcord;
        if (speedMod)
        {
            body.AddForce(playerMoveTrack * Time.deltaTime*speed*movementMulti);
            /*transform.up = (Vector2) Vector3.Slerp(transform.up, playerMoveTrack, 2 * Time.deltaTime);
            velocity += playerMoveTrack.magnitude * Time.deltaTime;
            velocity -= velocity * brakingForce * Time.deltaTime;*/
        }
        else
        {
            gurglegurgle += Time.deltaTime;
            if(gurglegurgle>TimeToDrown)Respawn();
            
            if (delta.magnitude < 0.02f&&body.linearVelocity.y==0&&LeapVec!=Vector2.zero)
            {
                Debug.Log("once");
                gurglegurgle -= FlopBreath;
           //add force to push player when they flop
           body.linearVelocity = new Vector2(LeapVec.x * leapForce * 3, 10 * leapForce);
           //body.AddForce(new Vector2(LeapVec.x*leapForce*3,10*leapForce));
            }
            //transform.up = (Vector2) Vector3.Slerp(transform.up, Vector2.down, 0.5f * Time.deltaTime);
        }

        
        if (delta.magnitude > 0.01f)
        {
            transform.up = Vector3.Slerp(transform.up, transform.position - prevcord, 0.9f);
        }

        // transform.position+=transform.up*Time.deltaTime*velocity*speed;
   prevcord = transform.position;
   if (sb1 > 0 && sb2 > 0)
   {
       movementMulti = boostForce;
   }
   else
   {
       movementMulti = 1;
           
   }
    }

    private void OnMove(InputValue value)
    {
        if (!speedMod) return;
        playerMoveTrack = value.Get<Vector2>();
    }
    private void OnHop(InputValue value)
    {
      //  if (speedMod || delta.magnitude < 0.02f || body.linearVelocity.y == 0) return;
       // Debug.Log("leap");
        LeapVec = value.Get<Vector2>();
    }

    private void OnSprint(InputValue value)
    {
      sb1 = value.Get<float>();
    }
    private void OnSprint1(InputValue value)
    {
        sb2 = value.Get<float>();
        
        
    }

    private void OnAttack()
    {
        if (food.Count == 0) return;
        /*foreach (var i in food)
        {
            Destroy(i);
        }*/
        eat.Play();
        for (int i = 0; i < food.Count; i++)
        {
            Destroy(food[i]);
        }

        food = new List<GameObject>();
        Debug.Log("ff");
    }

    public void enterWater()
    {
        speedMod = true;
        body.gravityScale = 0;
        playerMoveTrack=Vector2.down;
        splash.Play();
        gurglegurgle = 0;
      //  Debug.Log(body.linearVelocity);
      //  playerMoveTrack = transform.up;
      //  velocity *= 0.5f;
       //  body.linearVelocity = Vector2.zero;
    }

    public void exitWater()
    {
        speedMod = false;
        //if (transform.up == Vector3.up) {
          //  Debug.Log("my people need me");
           // transform.up = (Vector2) Vector3.Slerp(transform.up, Vector2.left, 0.5f * Time.deltaTime);
        //}
        splash.Play();
        respawn = transform.position;
     body.gravityScale = gravityStrength;
    }

    private void Respawn()
    {
        body.position = respawn + Vector3.down;
        body.linearVelocity=Vector2.zero;
        Debug.Log("he is contained");
    }
}
