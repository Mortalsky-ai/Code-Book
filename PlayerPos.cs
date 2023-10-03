using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    private GameManager gameManager;
    void Start()
    {
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
        transform.position=gameManager.lastCheckpointPos;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
