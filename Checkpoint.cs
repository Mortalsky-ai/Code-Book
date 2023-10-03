using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameManager gameManager;
    public Sprite checkpointOn;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name=="Player")
        {
            Debug.Log("Checkpoint reached!");
            gameManager.lastCheckpointPos = transform.position;
            GetComponent<SpriteRenderer>().sprite=checkpointOn;
        }
    }
}
