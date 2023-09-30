using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.SceneManagement;
using static UnityEditor.Recorder.OutputPath;

public class Aimandattack : MonoBehaviour
{
    public float Aim(Rigidbody2D rb,Vector3 bullet_offset) // returns angle of aim w.r.t. mouse in radian 
    {
        Vector3 mouseposition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        float aim_angle = Mathf.Atan2(mouseposition.y - rb.position.y - bullet_offset.y, mouseposition.x - rb.position.x - bullet_offset.x);
        return aim_angle;
    } 

    public void Long_fire(Rigidbody2D bullet, Vector3 bullet_offset, Quaternion rotation, Transform parent,float aim_angle , float bullet_speed) // use to  fire anything
    {
        Rigidbody2D new_bullet = Instantiate(bullet, parent.position+bullet_offset, rotation, parent);
        new_bullet.velocity = new Vector2(bullet_speed * Mathf.Cos(aim_angle), bullet_speed * Mathf.Sin(aim_angle));
        //new_bullet.velocity = bullet_velocity;
    }

    public void Rotate_with_velocity(Rigidbody2D bullet) // use to rotate arrow in place of bullet in direction of projectile, need to attach this script in arrow prefab
    {
        float velocity_angle = Mathf.Atan2(bullet.velocity.y, bullet.velocity.x) * Mathf.Rad2Deg;
        bullet.rotation = velocity_angle;
    }

    public void Melee_attack(Animator attack,string attacking,bool is_attacking) // srting is the name of transition bool, bool should be true when key is pressed, false otherwise
    {
        attack.SetBool(attacking, is_attacking);
    }

    public void Trajectory_simulator( Rigidbody2D bullet,Vector3 bullet_offset, Transform parent, float aim_angle, float bullet_speed, LineRenderer line, int length_points) // simulates the path of projectile before hand 
    {
        line.enabled = true;
        Vector3 startPosition = parent.position + bullet_offset;
        Vector3 startVelocity = new Vector3(bullet_speed * Mathf.Cos(aim_angle), bullet_speed * Mathf.Sin(aim_angle), 0);
        line.SetPosition(0, startPosition);
        int i = 0;
        Vector3 prev_point = parent.position + bullet_offset;
        for (float j = 0; i < length_points; j += 0.05f)
        {
            line.positionCount = i+1;
            Vector3 linePosition = startPosition + j * startVelocity;
            linePosition.y = startPosition.y + startVelocity.y * j + 0.5f * bullet.gravityScale *-9.81f * j * j;
            if(Physics2D.Raycast(prev_point,linePosition - prev_point, Vector3.Distance(linePosition, prev_point)))
            {
                Debug.Log("happening");
                line.SetPosition(i,linePosition);
                break;
            }
            line.SetPosition(i, linePosition);
            prev_point = linePosition;
            i++;
        }
    }
}
