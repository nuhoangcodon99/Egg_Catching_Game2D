using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------Audio Sources------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------Audio Clips--------")]
    public AudioClip musicClip;
    public AudioClip SFXClip;

    public void PlayMusic()
    {
        if (!musicSource.isPlaying && musicClip != null) 
        {
            musicSource.clip = musicClip;
            musicSource.Play();
        }
        else if (musicSource.isPlaying) 
        {
            musicSource.UnPause();
        }
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            SFXSource.PlayOneShot(clip);
        }
    }
}
