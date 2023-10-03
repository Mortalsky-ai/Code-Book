using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public Vector2 lastCheckpointPos;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }

    }
}
