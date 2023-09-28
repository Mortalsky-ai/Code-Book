using UnityEngine;
using System;

public class Character_Movement : MonoBehaviour
{
    public Rigidbody player;
    public float speed=10.0f;


    public void Movement(Rigidbody player,float speed)
    {   
        float move;
        move=Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        player.position+=new Vector3 (move,0,0);
    }
    public void jump(Rigidbody player,float speed)
    {   
        
        // float move=speed*Time.deltaTime;
        player.velocity = new Vector3(0, 1, 0) * speed;
    }
    public void dash(Rigidbody player,float speed){
        player.velocity = player.forward* speed;
    }

}
