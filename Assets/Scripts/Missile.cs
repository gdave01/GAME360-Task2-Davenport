using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 10f;
    public float duration = 3f;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;

        Destroy(gameObject, duration);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy)
            {
                enemy.TakeDamage(2);
                GameManager.Instance.AddScore(50);
                Destroy(gameObject);
                Debug.Log("enemy hit!");
            }
        }

        if (other.CompareTag("Bounds"))
        {
            Destroy(gameObject);
            Debug.Log("Hit Wall");
        }
    }
}