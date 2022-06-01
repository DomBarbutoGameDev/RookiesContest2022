using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (audioSource == null)
        {
            Debug.Log("No audio source component");
        }

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

}
