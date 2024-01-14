using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    [SerializeField] Animator animator;

    public float collisionIntensityThreshold;
    public float intensity;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float collisionIntensity = collision.relativeVelocity.magnitude;

        if (collision.gameObject.CompareTag("Wall") ||
            collision.gameObject.CompareTag("Ball") ||
            collision.gameObject.CompareTag("Car"))
        {
            if (collisionIntensity >= collisionIntensityThreshold)
            {
                animator.Play("CarCollision");
            }
        }
    }
}
