using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text scoreTxt;
    public TMP_Text text;

    private void Start()
    {
        Debug.Log("UI Manager active");

        EventManager.Subscribe("OnScoreChanged", UpdateScore);
        EventManager.Subscribe("OnPlayerHealthChanged", UpdateHealth);
        EventManager.Subscribe("OnEnemyDefeated", UpdateTBD);
        EventManager.Subscribe("OnLevelComplete", UpdateScene);
        EventManager.Subscribe("OnPowerUpCollected", UpdateTBD);
    }

    private void UpdateScene()
    {
        throw new NotImplementedException();
    }

    private void UpdateTBD()
    {
        throw new NotImplementedException();
    }

    private void UpdateHealth()
    {
        throw new NotImplementedException();
    }

    private void UpdateScore(object scoreData)
    {
        if (scoreTxt != null)
        {
            scoreTxt.text = "Score: " + scoreData.ToString();
        }
    }
}
