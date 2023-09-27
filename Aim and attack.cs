using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimandattack : MonoBehaviour
{
    public float Aim(Rigidbody2D rb) // returns angle of aim w.r.t. mouse in radian 
    {
        Vector3 mouseposition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        float aim_angle = Mathf.Atan2(mouseposition.y - rb.position.y, mouseposition.x - rb.position.x);
        return aim_angle;
    } 

    public Rigidbody2D Long_fire(Rigidbody2D bullet, Vector3 bullet_offset, Quaternion rotation, Transform parent, float aim_angle, float bullet_speed) // use to  fire anything
    {
        Rigidbody2D new_bullet = Instantiate(bullet, parent.position+bullet_offset, rotation, parent);
        new_bullet.velocity = new Vector2(bullet_speed * Mathf.Cos(aim_angle), bullet_speed * Mathf.Sin(aim_angle));
        return new_bullet; // Store this return in a list to take further actions on these bullets like the rotate with velocity as below
    }

    public void Rotate_with_velocity(Rigidbody2D bullet) // use to rotate arrow in place of bullet in direction of projectile
    {
        float velocity_angle = Mathf.Atan2(bullet.velocity.y, bullet.velocity.x) * Mathf.Rad2Deg;
        bullet.rotation = velocity_angle;
    }

    public void Melee_attack(Animator attack,string attacking,bool is_attacking) // srting is the name of transition bool, bool should be true when key is pressed, false otherwise
    {
        attack.SetBool(attacking, is_attacking);
    }
}
