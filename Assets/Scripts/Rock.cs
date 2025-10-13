using System;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [Header("Asteroid Settings")]
    public float rotationSpeed = 90f;
    public int rockValue = 10;

    private void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Mine();
        }
    }

    private void Mine()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(rockValue);
        }
        //EventManager.TriggerEvent("OnPowerUpCollected", rockValue);
    }
}

