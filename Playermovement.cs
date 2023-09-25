using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jumpspeed;
    public float jumpHeight = 1;
    float mH;
    public SpriteRenderer sr;
    float Time = 0;
    public float Dashduration = 1;
    public float dashforce = 10;

    public void Movement()
    {
        mH = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(mH * speed, 0);
    }

    public void Jump()
    {
        if (Input.GetKey(KeyCode.Space) )
        {
            rb.velocity = new Vector2(mH * speed, jumpspeed);
        }

    }

    public void dash()
    {
        if (Input.GetKey(KeyCode.LeftShift)){
            if (Time < Dashduration)
            {
                rb.AddForce(mH *Vector2.right * dashforce);
            }
        }
    }
}