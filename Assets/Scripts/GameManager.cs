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
    public void OnLoad (Scene scene, LoadSceneMode mode)
    {
        refreshReferences();
        updateUI();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLoad;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLoad;
    }
    void Start()
    {
        
        SceneManager.LoadScene(0);
        if (startButton != null)
            startButton.onClick.AddListener(startGame);
        if (quitButton != null)
            quitButton.onClick.AddListener(quitGame);
    }

    private void refreshReferences()
    {
        scoreTxt = GameObject.Find("Score")?.GetComponent<Text>();
        livesTxt = GameObject.Find("Lives")?.GetComponent<Text>();
    }

    private void updateUI()
    {
        if (scoreTxt) 
            scoreTxt.text = "Score: " + score;
        if (livesTxt) 
            livesTxt.text = "Lives: " + lives;
    }
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quit application");
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Start clicked");
    }

    public void AddScore(int points)
    {
        score += points;
        EventManager.TriggerEvent("OnScoreChanged", score);
        //updateUI();
        Debug.Log($"Increased score by {points}. Total: {score}");
    }

    public void loseLife()
    {
        lives--;
        EventManager.TriggerEvent("OnPlayerHealthChanged", lives);
        //updateUI();
        Debug.Log($"Hit by enemy! Lives remaining: {lives}");

        if (lives <= 0)
            gameOver();
    }

    private void gameOver()
    {
        destroyAll();
        //Application.Quit();
        EventManager.TriggerEvent("OnLevelComplete", score);
        EventManager.ClearAllEvents();
        Debug.Log("Ship Destroyed - Game Over!");
    }

    public void enemyDefeated()
    {
        enemiesDefeated++;
        AddScore(50);
        Debug.Log($"Ship blown up! Total alien ships defeated: {enemiesDefeated}");
    }

    /*public void rockValue (int value)
    {
        AddScore(value);
        Debug.Log($"Asteroid worth {value} points.");
    }*/

    private void destroyAll()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        
        GameObject[] missiles = GameObject.FindGameObjectsWithTag("Missile");
        foreach (GameObject missile in missiles)
        {
            Destroy(missile);
        }
        
        GameObject[] rocks = GameObject.FindGameObjectsWithTag("rock");
        foreach (GameObject rock in rocks)
        {
            Destroy(rock);
        }
    }
}
