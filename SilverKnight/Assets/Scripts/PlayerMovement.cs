using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim; 
    private enum State {idle, running, jumping, falling}
    private State state = State.idle;
    private Collider2D coll;
    [SerializeField] private LayerMask ground;
    

   
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    private void Update()
    {

        float hDirection = Input.GetAxis("Horizontal");

        if(hDirection < 0) 
        {
            rb.velocity = new Vector2(-8, rb.velocity.y); //the player will move left at a speed of -8
            transform.localScale = new Vector2(-1.5f, 1.5f); //the player will face left at a value of -1.5 with a height of 1.5
        }

       else if (hDirection > 0)
        {
            rb.velocity = new Vector2(8, rb.velocity.y); //the player will move right at a speed of 8
            transform.localScale = new Vector2(1.5f, 1.5f); //the player will face right at a value of 1.5 with a height of 1.5
        }
        else
        {
           
        }

        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground)) //if the space arrow is pressed
        {
            rb.velocity = new Vector2(rb.velocity.x, 20f); //the player will jump with a value of 10
            state = State.jumping;
        }
     
        VelocityState();
        anim.SetInteger("state", (int)state);

        
    }
                         
    private void VelocityState()
    {
        if(state == State.jumping)
        {
            if(rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if(state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }

        else if(Mathf.Abs(rb.velocity.x) > 2f) //if the velocity inside the x-axis is greater than 0.1
        {
            //Moving
            state = State.running;
        }

        else
        {
            state = State.idle;
        }
        
    }

    

    
}
