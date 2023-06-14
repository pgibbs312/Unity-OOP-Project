using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAudioSource : MonoBehaviour
{
    public void PlayDeathSound(AudioClip deathSound)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = deathSound;
        audioSource.Play();
    }
}
