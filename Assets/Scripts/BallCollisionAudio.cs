using UnityEngine;

public class BallCollisionAudio : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 0.2f)
        {
            audioSource.Play();
        }
    }
}