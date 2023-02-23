using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem dustTrailEffect;
    [SerializeField] AudioClip snowboardSFX;
    bool soundPlayed = false;

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ground")
        {        
            dustTrailEffect.Play();
            if(!soundPlayed)
            {
                GetComponent<AudioSource>().PlayOneShot(snowboardSFX);
                soundPlayed = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ground")
        {
            dustTrailEffect.Stop();
            GetComponent<AudioSource>().Stop();
            soundPlayed = false;
        }
    }
}
