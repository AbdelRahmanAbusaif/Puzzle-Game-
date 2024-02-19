using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Component")]
    public AudioSource SFXAudio;
    public AudioSource BackGroundMusic;

    [Header("Audio Clip")]
    public AudioClip Music;
    public AudioClip JupmSound;
    public AudioClip TransitionPortalSound;
    public AudioClip TransitionBoxSound;
    public AudioClip DeathSound;
    public AudioClip WinSound;
    public AudioClip ShootingSound;
    public AudioClip ClickSound;
    public AudioClip KeySound;

    private void Start()
    {
        BackGroundMusic.clip = Music;
        BackGroundMusic.Play();
    }

    public void PlayClip(AudioClip clip)
    {
        SFXAudio.PlayOneShot(clip);
    }
}
