using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Collision : MonoBehaviour
{
    Rigidbody2D rb;
    public attack ana;
    public float f=1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ana.Rotate_with_velocity(rb);
        if(f<0f) Destroy(rb.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("bullet"))  f-=1f;
       
    }
}