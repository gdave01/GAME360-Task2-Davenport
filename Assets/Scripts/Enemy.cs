using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Ship Stats")]
    public int hp = 4;
    public float moveSpeed = 2.4f;
    public float shipDuration = 20f;

    public float detectRange = 2000f;

    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj) player = playerObj.transform;

        Destroy(gameObject, shipDuration);
    }
    void Update()
    {
        Follow();
    }
    private void Follow()
    {
        if (player)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance <= detectRange)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                rb.linearVelocity = direction * moveSpeed;
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
        EventManager.TriggerEvent("OnEnemyDefeated");
        Destroy(gameObject);
    }
}