using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Button startButton;
    public Button quitButton;

    public GameObject sButton;
    public GameObject qButton;
    public GameObject title;

    public int score = 0;
    public int lives = 5;
    public int enemiesDefeated = 0;

    public Text scoreTxt;
    public Text livesTxt;
    public Text enemiesTxt;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("GameManager Created");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Duplicate destroyed - Only one GameManager allowed");
        }
    }
    void Start()
    {
        SceneManager.LoadScene(0);
        if (startButton != null)
            startButton.onClick.AddListener(startGame);
        if (quitButton != null)
            quitButton.onClick.AddListener(quitGame);
    }
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quit application");
    }
    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        score = 0;
        lives = 5;
        Debug.Log("Start clicked");
    }
    public void AddScore(int points)
    {
        score += points;
        EventManager.TriggerEvent("OnScoreChanged", score);
        Debug.Log($"Increased score by {points}. Total: {score}");
    }
    public void loseLife()
    {
        lives--;
        EventManager.TriggerEvent("OnPlayerHealthChanged", lives);
        Debug.Log($"Hit by enemy! Lives remaining: {lives}");

        if (lives <= 0)
            gameOver();
    }
    public void gainLife()
    {
        lives++;
        EventManager.TriggerEvent("OnPlayerHealthChanged", lives);
        EventManager.TriggerEvent("OnPowerUpCollected", lives);
    }
    private void gameOver()
    {
        EventManager.TriggerEvent("OnGameOver", score);
        EventManager.ClearAllEvents();
        Debug.Log("Ship Destroyed - Game Over!");
    }

    public void enemyDefeated()
    {
        enemiesDefeated++;
        AddScore(50);
        Debug.Log($"Ship blown up! Total alien ships defeated: {enemiesDefeated}");
    }
}