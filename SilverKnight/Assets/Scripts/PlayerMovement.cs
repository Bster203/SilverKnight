using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim; //connects the player to the animator

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)) //If the left arrow key is pressed and the right arrow key is NOT pressed
        {
            rb.velocity = new Vector2(-5, rb.velocity.y); //the player will move left at a value of -5
            transform.localScale = new Vector2(-1.5f, 1.5f); //the player will face left at a value of -1.5 with a height of 1.5
            anim.SetBool("running", true); //the player will run left
        }

       else if (Input.GetKey(KeyCode.RightArrow)) //If the right arrow is pressed and the left arrow key is NOT pressed
        {
            rb.velocity = new Vector2(5, rb.velocity.y); //the player will move right at a value of 5
            transform.localScale = new Vector2(1.5f, 1.5f); //the player will face right at a value of 1.5 with a height of 1.5
            anim.SetBool("running", true); //the player will run right
        }
        else
        {
            anim.SetBool("running", false); //if the left arrow key is NOT pressed and the right arrow key is NOT pressed, the player will idle
        }

        if (Input.GetKeyDown(KeyCode.Space)) //if the space arrow is pressed
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f); //the player will jump with a value of 10
        }
    }
}
