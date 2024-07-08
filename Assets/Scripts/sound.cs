using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    public AudioClip[] sounds;

    private AudioSource audioSrc => GetComponent<AudioSource>();

    public void soundPlay(AudioClip clip, float volume = 1f, bool destroyed = false, float p1 = 0.85f, float p2 = 1.2f)
    {
        audioSrc.pitch = 1f;
        audioSrc.PlayOneShot(clip, volume);
    }
}
