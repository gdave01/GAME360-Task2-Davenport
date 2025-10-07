using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    [Header("Spawning")]
    public GameObject alienPrefab;
    public float spawnRate = 6f;
    public Transform[] spawnPoints;

    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            spawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }
        if (GameManager.Instance.score > 400 && GameManager.Instance.score < 900)
            spawnRate = 1.5f;
        if (GameManager.Instance.score > 900 && GameManager.Instance.score < 1400)
            spawnRate = 1.0f;
        if (GameManager.Instance.score > 1400 && GameManager.Instance.score < 2000)
            spawnRate = 0.5f;
    }
    private void spawnEnemy()
    {
        if (alienPrefab && spawnPoints.Length > 0)
        {
            if (GameManager.Instance.lives > 0)
            {
                int randomIndex = Random.Range(0, spawnPoints.Length);
                Instantiate(alienPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
            }
        }
        
    }
}
