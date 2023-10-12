using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    Cursor_Based_Trajectory cbtobj;
    void Start()
    {
        cbtobj = new Cursor_Based_Trajectory();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Vector2 velocityVector=cbtobj.GetTrajectory();
            //Animation and Stuff
            if (Input.GetMouseButtonDown(0))
            {
                bullet.GetComponent<Rigidbody2D>().velocity = velocityVector;
            }
        }
    }
}
