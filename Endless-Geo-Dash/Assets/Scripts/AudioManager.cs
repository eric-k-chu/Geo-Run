/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the AudioManager class, which controls
the given audio sources in the game
*/

using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioGroup sfx_source;
    [SerializeField] private AudioGroup ui_source;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip move_sideways;
    [SerializeField] private AudioClip ui_button;
    [SerializeField] private AudioClip crystal_pickup;
    [SerializeField] private AudioClip checkpoint_pass;
    [SerializeField] private AudioClip checkpoint_fail;

    private void Awake()
    {
        instance = this;
    }

    public void PlayJumpSFX()
    {
        sfx_source.PlayClipAsOneshot(jump);    
    }

    public void PlayMoveSFX()
    {
        sfx_source.PlayClipAsOneshot(move_sideways);
    }

    public void PlayButtonUI()
    {
        ui_source.PlayClipAsOneshot(ui_button);
    }

    public void PlayCrystalPickupSFX()
    {
        sfx_source.PlayClipAsOneshot(crystal_pickup);
    }

    public void PlayCheckpointPassSFX()
    {
        sfx_source.PlayClipAsOneshot(checkpoint_pass);
    }

    public void PlayCheckPointFailSFX()
    {
        sfx_source.PlayClipAsOneshot(checkpoint_fail);
    }
}
