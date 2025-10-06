using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 8;
    public float moveSpeed = 1.2f;

    public float detectRange = 5.75f;

    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj) player = playerObj.transform;
    }

    void Update()
    {
        Follow();
    }
    private void Follow()
    {
        if (player)
        {
            //if (GameManager.Instance.score > 1000)
                //moveSpeed = 3f;
            //if (GameManager.Instance.score > 2000)
                //moveSpeed = 4f;
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance <= detectRange)
            {
                Vector2 direction = (player.position -
                transform.position).normalized;
                // rb.linearVelocity = direction * moveSpeed;
                rb.AddForce(direction * moveSpeed);
            }
            else
            {
                rb.linearVelocity = Vector2.zero;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
            Despawn();
    }

    private void Despawn()
    {
        GameManager.Instance.enemyDefeated();
        Destroy(gameObject);
    }

}
