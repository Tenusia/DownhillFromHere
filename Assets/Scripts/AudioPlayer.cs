using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioClip snowboardSFX;
    [SerializeField] [Range(0f,1f)] float snowboardSFXVolume = 1f;

    [SerializeField] AudioClip crashSFX;
    [SerializeField] [Range(0f,1f)] float crashSFXVolume = 1f;

    [SerializeField] AudioClip boostSFX;
    [SerializeField] [Range(0f,1f)] float boostSFXVolume = 1f;

    public void PlaySnowboardSFX()
    {
        if(snowboardSFX != null)
        {
            AudioSource.PlayClipAtPoint(snowboardSFX, 
                                        Camera.main.transform.position, 
                                        snowboardSFXVolume);
        }
    }

    public void PlayCrashSFX()
    {
        if(crashSFX != null)
        {
            AudioSource.PlayClipAtPoint(crashSFX, 
                                        Camera.main.transform.position, 
                                        crashSFXVolume);
        }
    }

    public void PlayBoostSFX()
    {
        if(boostSFX != null)
        {
            AudioSource.PlayClipAtPoint(boostSFX, 
                                        Camera.main.transform.position, 
                                        boostSFXVolume);
        }
    }
}
