using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public Vector2 lastCheckpointPos;
    public int score;
    public int lives;
    public int health;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }

    }
}
