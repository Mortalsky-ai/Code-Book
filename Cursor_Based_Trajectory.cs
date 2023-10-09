using UnityEngine;
using System;
public class Cursor_Based_Trajectory : MonoBehaviour
{
    public GameObject rb; //the Object Reference of the Bullet
    public double velocity;
    private double g;
    public void Start()
    {
        g = -Physics2D.gravity.y * GetComponent<Rigidbody2D>().gravityScale;
    }
    public Vector2 GetTrajectory()
    {

        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 bulletPos = rb.transform.position;

        double x = cursorPos.x - bulletPos.x;
        double y = cursorPos.y - bulletPos.y;
        double distance = Math.Sqrt(x * x + y * y);
        Debug.Log("Distance= " + distance);
        velocity = 1.1236 * distance + 8.163;
        double a = (g / 2.0) * (x * x) / (velocity * velocity);
        double det = (x * x - 4.0 * a * (y + a));

        if (det < 0)
        {
            Debug.Log("No solution");
            double t = velocity / Math.Sqrt(2);
            Vector2 max_velocityVector = new Vector2((float)t, (float)t);
            //Debug.Log("Velocity Vector = " + max_velocityVector);
            return new Vector2(Math.Sign(x) * max_velocityVector.x, max_velocityVector.y);
        }

        double tanTheta = (x + Math.Sign(x) * Math.Sqrt(det)) / (2 * a);
        double sinTheta = tanTheta / Math.Sqrt(1.0 + tanTheta * tanTheta);
        double cosTheta = 1.0 / Math.Sqrt(1.0 + tanTheta * tanTheta);

        Vector2 velocityVector = new Vector2((float)(velocity * cosTheta), (float)(velocity * sinTheta));
        //Debug.Log("Velocity= " + velocity);

        return x > 0 ? velocityVector : -velocityVector;
    }
    /*private void CalculateVelocity()
    {
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 bulletPos = rb.transform.position;
        double maxVelocity=Math.Sqrt(maxRange * g);
        double x = Math.Abs(cursorPos.x - bulletPos.x);
        Debug.Log("X=" + x+"  maxRange=="+maxRange+"  maxVelocity="+maxVelocity);
        velocity= (x/maxRange) * maxVelocity;
    }*/
}

