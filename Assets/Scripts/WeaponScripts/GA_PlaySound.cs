using UnityEngine;
using UnityEngine.Audio;
[RequireComponent (typeof(AudioSource))]

public class GA_PlaySound : GameAction
{
    public AudioResource soundToPlay;
    private AudioSource audioSource;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource> ();
    }

    public void PlaySound()
    {
        audioSource.resource = soundToPlay;
        audioSource.Play();
    }
}
