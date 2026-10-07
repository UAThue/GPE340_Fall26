using UnityEngine;

public class GA_PlaySound : GameAction
{
    public AudioClip soundToPlay;

    public void PlaySound()
    {
        AudioSource.PlayClipAtPoint(soundToPlay, transform.position);
    }
}
