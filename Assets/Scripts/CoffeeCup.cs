using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeCup : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip audioClipClink1;
    public AudioClip audioClipClink2;
    public AudioClip audioClipClink3;
    public AudioClip audioClipClink4;


    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.relativeVelocity.magnitude);

        if (collision.relativeVelocity.magnitude < 1.0f)
        { 
            audioSource.PlayOneShot(audioClipClink1, 0.3F);
        }
        else if (collision.relativeVelocity.magnitude < 2.0f)
        {
            audioSource.PlayOneShot(audioClipClink1, 0.5F);
        }
        else if(collision.relativeVelocity.magnitude < 3.0f)
        {
            audioSource.PlayOneShot(audioClipClink1, 0.7F);
        }
        else
        {
            audioSource.PlayOneShot(audioClipClink1, 0.97F);
        }
    }

}
