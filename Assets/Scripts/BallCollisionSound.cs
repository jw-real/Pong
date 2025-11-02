using UnityEngine;

public class BallCollisionSound : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Look for any IHitSound on the object we collided with
        IHitSound hitSound = collision.gameObject.GetComponent<IHitSound>();
        if (hitSound != null)
        {
            hitSound.PlayHitSound();
        }
    }
}