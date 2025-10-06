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
        refreshSys();
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
        //updateUI();
        //refreshSys();
        //SceneManager.LoadScene(0);
        if (startButton != null)
            startButton.onClick.AddListener(startGame);
        if (quitButton != null)
            quitButton.onClick.AddListener(quitGame);
    }

    private void updateUI()
    {
        scoreTxt = GameObject.Find("score")?.GetComponent<Text>();
        livesTxt = GameObject.Find("lives")?.GetComponent<Text>();
        enemiesTxt = GameObject.Find("enemiesDefeated")?.GetComponent<Text>();
    }

    private void refreshSys()
    {
        if (scoreTxt)
            scoreTxt.text = "Score: " + score;
        if (livesTxt) 
            livesTxt.text = "Lives: " + lives;
        if (enemiesTxt) 
            enemiesTxt.text = "Enemies: " + enemiesDefeated;
    }
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quit application");
    }

    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Start clicked");
    }

    public void AddScore(int points)
    {
        score += points;
        refreshSys();
        Debug.Log($"Increased score by {points}. Total: {score}");
    }

    public void loseLife()
    {
        lives--;
        refreshSys();
        Debug.Log($"Hit by enemy! Lives remaining: {lives}");

        if (lives <= 0)
            gameOver();
    }

    private void gameOver()
    {
        Debug.Log("Ship Destroyed - Game Over!");
        Time.timeScale = 0f;
    }

    public void enemyDefeated()
    {
        enemiesDefeated++;
        AddScore(50);
        Debug.Log($"Ship blown up! Total alien ships defeated: {enemiesDefeated}");
    }

    public void rockValue (int value)
    {
        AddScore(value);
        Debug.Log($"Asteroid worth {value} points.");
    }
}
