using UnityEngine;
using System;

public class Checkpoint : MonoBehaviour 
{
    public Transform player;
    public Vector2 respawn2d_at;
    // void Start(){
    //     player = GetComponent<Transform>(); 
    // }
    public void respawn2d(Vector2 respawn2d_at,Transform player){
        player.position=respawn2d_at;
        
    }
    public Vector2 Checkpoint_change(Vector2 new_respawn2d_at){
        respawn2d_at=new_respawn2d_at;
        return respawn2d_at;
    }
    public float is_dead(Transform p,float f){
        if(p.position.y<-2f) return (f-1) ;
        else return f;
    }
}