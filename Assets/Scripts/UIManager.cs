using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text scoreTxt;
    public TMP_Text livesTxt;
    void Start()
    {
        Debug.Log("UI Manager active");

        EventManager.Subscribe("OnScoreChanged", UpdateScore);
        EventManager.Subscribe("OnPlayerHealthChanged", UpdateHealth);
        EventManager.Subscribe("OnEnemyDefeated", UpdateScore);
        EventManager.Subscribe("OnGameOver", UpdateScene);
        EventManager.Subscribe("OnPowerUpCollected", UpdatePower);
    }
    private void UpdatePower()
    {
        GameManager.Instance.lives++;
        Debug.Log("Added 1 life");
    }
    private void UpdateScene(object finalScore)
    {
        SceneManager.LoadScene("MainMenu");
        GameManager.Instance.sButton.SetActive(true);
        GameManager.Instance.qButton.SetActive(true);
        GameManager.Instance.title.SetActive(true);
        Debug.Log("showing main menu");
    }
    private void UpdateHealth(object playerData)
    {
        if (livesTxt != null)
        {
            livesTxt.text = "Lives: " + playerData.ToString();
        }
    }
    private void UpdateScore(object scoreData)
    {
        if (scoreTxt != null)
        {
            scoreTxt.text = "Score: " + scoreData.ToString();
        }
    }
}