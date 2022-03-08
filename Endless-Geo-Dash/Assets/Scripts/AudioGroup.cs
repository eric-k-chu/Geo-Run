/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the AudioGroup class, which
contains functions that play audio clips
*/
using UnityEngine;

public class AudioGroup : MonoBehaviour
{
    private AudioSource audio_source;

    private void Awake()
    {
        audio_source = GetComponent<AudioSource>();
    }

    public void PlayClipAsOneshot(AudioClip clip)
    {
        audio_source.PlayOneShot(clip);
    }

    public void PlayClip(AudioClip clip, float delay)
    {
        audio_source.clip = clip;
        audio_source.PlayDelayed(delay);
    }
}
