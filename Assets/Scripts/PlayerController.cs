using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 2f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float boostReloadTimer = 5f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;        
    AudioPlayer audioPlayer;
    AudioSource audioSource;
    bool canMove = true;
    bool soundPlayed = false;
    
    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();   
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
       rb2d = GetComponent<Rigidbody2D> ();
       surfaceEffector2D = FindObjectOfType<SurfaceEffector2D> ();
    }

    void Update()
    {
        if(canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(Booster());
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
            soundPlayed = false;
        }
    }

    IEnumerator Booster()
    {
        surfaceEffector2D.speed = boostSpeed;
        if(!soundPlayed)
            {
                audioPlayer.PlayBoostSFX();
                soundPlayed = true;
            }
        yield return new WaitForSeconds(boostReloadTimer);
    }

}
