using UnityEngine;
using System;

public class Character_Movement : MonoBehaviour
{
    public Transform player;
    public float speed=10.0f;


    public void Movement(Transform player,float speed)
    {   
        float move;
        move=Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        player.position+=new Vector3 (move,0,0);
    }
    public void jump(Transform player,float speed)
    {   
        
        float move=speed*Time.deltaTime;
        player.position+=new Vector3 (0,move,0);
    }
}
