using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    [Header("Missile Setup")]
    private float fireRate = 0.5f;
    private float nextFireTime = 0f;
    public GameObject misslePrefab;
    public Transform misslePoint;

    [Header("Afterburner")]
    public GameObject exhaust;
    public GameObject burst;

    public Animator animator;

    private PlayerState currentState;

    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        ChangeState(new IdleState());
    }
    void Update()
    {
        HandleMovement();
        HandleShooting();
        
        if (currentState != null)
        {
            currentState.UpdateState(this);
        }
    }
    public void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical).normalized;
        rb.linearVelocity = movement * moveSpeed;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }

    public void HandleShooting()
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
        if (misslePrefab && misslePoint)
        {
            Instantiate(misslePrefab, misslePoint.position, misslePoint.rotation);
        }
        AudioManager.Instance.PlayFireSound();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameManager.Instance.loseLife();
            AudioManager.Instance.PlayDamageSound();
        }
        if (other.CompareTag("rock"))
        {
            Rock rock = other.GetComponent<Rock>();
            if (rock)
            {
                AudioManager.Instance.PlayMineSound();
                Destroy(other.gameObject);
            }
        }

        if (other.CompareTag("Pills"))
        {
            GameManager.Instance.gainLife();
            AudioManager.Instance.PlayHealthSound();
            Destroy(other.gameObject);
        }
    }
    public void ChangeState(PlayerState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState(this);
        }

        currentState = newState;
        currentState.EnterState(this);

        EventManager.TriggerEvent("OnPlayerStateChanged", currentState.GetStateName());
    }
}