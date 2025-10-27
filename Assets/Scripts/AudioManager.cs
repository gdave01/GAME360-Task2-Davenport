using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource audioSource;

    [Header("Audio Clips")]
    public AudioClip missileSound;
    public AudioClip rockSound;
    public AudioClip healthPickup;
    public AudioClip playerHit;
    public AudioClip flying;
    public AudioClip enemyDied;

    public static AudioManager Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    public void PlayClip(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void PlayFireSound() => PlayClip(missileSound);
    public void PlayMineSound() => PlayClip(rockSound);
    public void PlayHealthSound() => PlayClip(healthPickup);
    public void PlayDamageSound() => PlayClip(playerHit);
    public void PlayFlySound() => PlayClip(flying);
}