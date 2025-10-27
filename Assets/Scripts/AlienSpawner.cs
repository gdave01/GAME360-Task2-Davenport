using Unity.VisualScripting;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    [Header("Spawning")]
    public GameObject alienPrefab;
    public float spawnRate = 6f;
    public Transform[] spawnPoints;

    private float nextSpawnTime = 0f;

    public float radius;

    public Collider2D[] colliders;

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
                Vector3 spawnPos = new Vector3(0,0,0);
                bool spotOpen = false;
                
                while (!spotOpen)
                {
                    float spawnPosX = Random.Range(-8f, 8f);
                    float spawnPosY = Random.Range(-5f, 6f);

                    spawnPos = new Vector3(spawnPosX, spawnPosY, 0);
                    spotOpen = preventOverlap(spawnPos);

                    if (spotOpen)
                        break;
                }
                Instantiate(alienPrefab, spawnPos, Quaternion.identity);
            }
        }
    }
    bool preventOverlap(Vector3 spawnPos)
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 centerPoint = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.x;
            float height = colliders[i].bounds.extents.y;

            float leftExtent = centerPoint.x - width;
            float rightExtent = centerPoint.x + width;
            float lowerExtent = centerPoint.y - height;
            float upperExtent = centerPoint.y + height;

            if (spawnPos.x >= leftExtent && spawnPos.x <= rightExtent)
            {
                if(spawnPos.y >= lowerExtent && spawnPos.y <= upperExtent)
                {
                    return false;
                }
            } 
        }
        return true;
    }
}