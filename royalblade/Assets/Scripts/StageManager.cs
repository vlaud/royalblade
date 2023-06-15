using playerController;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance = null;
    public Player player;
    public Spawner spawner;
    private void Awake()
    {
        instance = this;
    }
}
