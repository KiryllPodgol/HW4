using Script;
using UnityEngine;
public class AudioManager : Singleton<AudioManager>
{
    [Header("Audio Clips")]
    public AudioClip shootSound;
    public AudioClip hitSound;
    public AudioClip bounceSound;
    public AudioClip explosionSound;
    private AudioSource audioSource;

    protected override void Awake()
    {
        base.Awake();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; 
        audioSource.loop = false;

        Debug.Log("AudioManager initialized.");
    }
    public void PlayShootSound()
    {
        PlaySound(shootSound);
    }

    public void PlayHitSound()
    {
        PlaySound(hitSound);
    }

    public void PlayBounceSound()
    {
        PlaySound(bounceSound);
    }

    public void PlayExplosionSound()
    {
        PlaySound(explosionSound);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("Attempted to play a null audio clip.");
        }
    }
}