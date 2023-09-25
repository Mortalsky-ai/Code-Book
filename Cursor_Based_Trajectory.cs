using UnityEngine;
using System;
public class Cursor_Based_Trajectory : MonoBehaviour
{
    public int velocity;
    public int g;
    public Vector2 GetTrajectory()
    {
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        double x = cursorPos.x - payLoad.transform.position.x;
        double y = cursorPos.y - payLoad.transform.position.y;
        //if(cursorPos.x-payLoad.transform.position.x>(velocity*velocity)/g)
        double a = (g / 2.0) * (x * x) / (velocity * velocity);
        double det = (x * x - 4.0 * a * (y + a));
        if (det < 0)
        {
            Debug.Log("No solution");
            Vector2 max_velocityVector = new Vector2((velocity * velocity) / 2 * g, 0);
            return Math.Sign(x) * max_velocityVector;
        }
        double tanTheta = (x + Math.Sqrt(det)) / (2 * a);
        double sinTheta = tanTheta / Math.Sqrt(1.0 + tanTheta * tanTheta);
        double cosTheta = 1.0 / Math.Sqrt(1.0 + tanTheta * tanTheta);
        Vector2 velocityVector = new Vector2((float)(velocity * cosTheta), (float)(velocity * sinTheta));
        return velocityVector;
    }
        /*
    public Vector2 GetTrajectory()
    {
        Vector2 velocityVector = GetVelocity();
        //Animation and stuff

        if (Input.GetMouseButtonDown(0))
        {
            payLoad.GetComponent<Rigidbody2D>().velocity = velocityVector;
        }
        return velocityVector;
    }
        */
}

