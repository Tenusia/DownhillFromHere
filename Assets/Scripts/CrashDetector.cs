using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float crashTime = 1f;
    [SerializeField] ParticleSystem crashEffect;
    AudioPlayer audioPlayer;
    bool hasCrashed = false;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();   
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            audioPlayer.PlayCrashSFX();
            Invoke("CrashSequence", crashTime);
        }
    }

    void CrashSequence()
    {
        SceneManager.LoadScene(0);
    }
}
