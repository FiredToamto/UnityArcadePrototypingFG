using UnityEngine;

public class Respawner : MonoBehaviour
{
    private Vector3 spawnPos;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = GetComponent<Transform>().position;
        player = GetComponent<Transform>();
    }

    public void Respawn()
    {
        player.position = spawnPos;
    }
}
