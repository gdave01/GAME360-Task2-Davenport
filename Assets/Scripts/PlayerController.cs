using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private float fireRate = 0.5f;
    private float nextFireTime = 0f;
    public GameObject misslePrefab;
    public Transform misslePoint;

    [Header("Audio")]
    public AudioClip missleSound;
    public AudioClip rockSound;
    private AudioSource audioSource;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.playOnAwake = false;
        audioSource.volume = 0.8f;
    }
    void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical).normalized;
        rb.linearVelocity = movement * moveSpeed;
        
    }

    private void HandleShooting()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            FireMissle();
            nextFireTime = Time.time + fireRate;
            Debug.Log("Projectile Fired!");
        }
    }

    private void FireMissle()
    {
        if (GameManager.Instance.score > 499 && GameManager.Instance.score < 1000)
            fireRate = 0.3f;
        if (GameManager.Instance.score > 1000)
            fireRate = 0.1f;
        if (misslePrefab && misslePoint)
        {
            Instantiate(misslePrefab, misslePoint.position, misslePoint.rotation);
        }

        audioSource.PlayOneShot(missleSound);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameManager.Instance.loseLife();
        }
        if (other.CompareTag("rock"))
        {
            Rock rock = other.GetComponent<Rock>();
            if (rock)
            {
                audioSource.PlayOneShot(rockSound);
                GameManager.Instance.rockValue(20);
                Destroy(other.gameObject);
            }
        }
    }
}