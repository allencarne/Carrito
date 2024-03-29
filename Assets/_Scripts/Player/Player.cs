using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] CustomPlayerInput playerInput;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] TrailRenderer leftAccelerateTrail;
    [SerializeField] TrailRenderer rightAccelerateTrail;
    [SerializeField] TrailRenderer leftDriftTrail;
    [SerializeField] TrailRenderer rightDriftTrail;
    public ParticleSystem boostTrail;

    [SerializeField] GameObject accTrailLeft;
    [SerializeField] GameObject accTrailRight;
    [SerializeField] GameObject preBoostTrail;

    float speed = 10;
    float torque = -350;
    float boostForce = 0.3f;
    float driftForce = 0.1f;

    public float currentBoost;
    [HideInInspector] public float maxBoost = 100;

    public bool isDrifting = false;
    public bool isBoosting = false;

    private void FixedUpdate()
    {
        if (SoccerManager.instance != null && !SoccerManager.instance.CanMove)
        {
            if (playerInput.IsAccelerating)
            {
                accTrailLeft.SetActive(true);
                accTrailRight.SetActive(true);
            }
            else
            {
                accTrailLeft.SetActive(false);
                accTrailRight.SetActive(false);
            }

            if (playerInput.IsBoosting)
            {
                preBoostTrail.SetActive(true);
            }
            else
            {
                preBoostTrail.SetActive(false);
            }
        }
        else
        {
            accTrailLeft.SetActive(false);
            accTrailRight.SetActive(false);
            preBoostTrail.SetActive(false);
        }

        if ((SoccerManager.instance != null && SoccerManager.instance.CanMove) || (RaceManager.instance != null && RaceManager.instance.CanMove))
        {
            rb.velocity = ForwardVelocity() + RightVelocity() * driftForce;

            Steer(playerInput.SteerInput);

            Accelerate(playerInput.Acceleration);

            if (playerInput.IsBraking) Break();

            if (playerInput.IsBoosting) Boost(); else NoBoost();

            if (currentBoost <= 0) NoBoost();

            if (playerInput.IsDrifting) Drift(); else NoDrift();
        }
    }

    void Steer(Vector2 inputValue)
    {
        float horizontalInput = inputValue.x;

        rb.angularVelocity = horizontalInput * torque;
    }

    void Accelerate(float acceleration)
    {
        float actualSpeed = acceleration * speed; // Scale the speed based on acceleration

        rb.AddForce(transform.up * actualSpeed);

        leftAccelerateTrail.emitting = true;
        rightAccelerateTrail.emitting = true;
    }

    void Decelerate()
    {
        leftAccelerateTrail.emitting = false;
        rightAccelerateTrail.emitting = false;
    }

    void Break()
    {
        rb.AddForce(transform.up * -speed);
    }

    void Boost()
    {
        if (currentBoost >= 1)
        {
            isBoosting = true;

            currentBoost--;
            rb.AddForce(transform.up * boostForce);
            rb.AddForce(transform.up * boostForce, ForceMode2D.Impulse);

            if (!boostTrail.isEmitting)
            {
                boostTrail.Play();
            }
        }
    }

    void NoBoost()
    {
        isBoosting = false;

        if (boostTrail.isEmitting)
        {
            boostTrail.Stop();
        }
    }

    void Drift()
    {
        isDrifting = true;

        driftForce = 1f;
        leftDriftTrail.emitting = true;
        rightDriftTrail.emitting = true;
    }

    void NoDrift()
    {
        isDrifting = false;

        driftForce = 0.1f;
        leftDriftTrail.emitting = false;
        rightDriftTrail.emitting = false;
    }

    Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up);
    }

    Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.right);
    }

    public float GetVelocityMagnitude()
    {
        return rb.velocity.magnitude;
    }
}
