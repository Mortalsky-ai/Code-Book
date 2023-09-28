using UnityEngine;
using System;

public class Checkpoint 
{
    public Transform player;
    public Vector3 respawn_at;
    // void Start(){
    //     player = GetComponent<Transform>(); 
    // }
    public void respawn(Vector3 respawn_at,Transform player){
        player.position=respawn_at;
    }
    public Vector3 Checkpoint_change(Vector3 new_respawn_at){
        respawn_at=new_respawn_at;
        return respawn_at;
    }
    public bool is_dead(Transform p){          
        if(p.position.y<-1f) return true;
        else return false;
    }
}