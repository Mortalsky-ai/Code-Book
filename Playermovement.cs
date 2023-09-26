using Unity.VisualScripting;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public void Movement(Rigidbody2D rb, float speed, float mH) // mH gives Horizontal direction of movement
    {
        rb.velocity = new Vector2(mH * speed, rb.velocity.y);
    }

    public void Jump(Rigidbody2D rb, float jumpspeed)
    {
             rb.velocity = new Vector2(rb.velocity.x, jumpspeed); 

    }

    public void dash(Rigidbody2D rb, float dashforce, float Dashduration, float dash_dir) 
        /* take dash_dir by 
     if(Input.GetAxisRaw("Horizontal") != 0)
    {
        dash_dir = Input.GetAxisRaw("Horizontal");
    }*/
    {
        float time = 0;

            while (time < Dashduration)
            {
                rb.AddForce( dash_dir *Vector2.right * dashforce);
                time += Time.deltaTime;
            }
    }
}