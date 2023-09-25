using Unity.VisualScripting;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jumpspeed;
    public float jumpHeight = 1;
    float mH;
    public SpriteRenderer sr;
    float time = 0;
    public float Dashduration = 0.5f;
    public float dashforce = 10;
    float dash_dir;

    public void Movement()
    {
        mH = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(mH * speed, 0);
        if (Input.GetAxisRaw("Horizontal") != 0) { dash_dir = Input.GetAxisRaw("Horizontal"); }
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
            while (time < Dashduration)
            {
                rb.AddForce( dash_dir*Vector2.right * dashforce);
                time += Time.deltaTime;
            }
            time = 0;
        }
    }
}