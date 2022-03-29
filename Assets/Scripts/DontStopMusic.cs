using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DontStopMusic : MonoBehaviour
{

    AudioSource WinSound;


void Start()
{
            WinSound = GetComponent<AudioSource>();

}


void Update()
{
    WinSound.Play();
}

    void Awake()
    {
    }
}
