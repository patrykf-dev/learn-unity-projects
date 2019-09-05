using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


    private void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    private void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Vector3 position = spawnPoints[spawnPointIndex].position;
        Quaternion rotation = spawnPoints[spawnPointIndex].rotation;
        Instantiate(enemy, position, rotation);
    }
}
