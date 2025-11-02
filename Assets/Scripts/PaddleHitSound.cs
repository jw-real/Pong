using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PaddleHitSound : MonoBehaviour, IHitSound
{
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayHitSound()
    {
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.Play();
    }
}
