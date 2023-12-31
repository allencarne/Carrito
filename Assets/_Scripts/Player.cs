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
    [SerializeField] TrailRenderer boostTrail;

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
        if (playerInput.IsAccelerating && !SoccerManager.instance.CanMove)
        {
            accTrailLeft.SetActive(true);
            accTrailRight.SetActive(true);
        }
        else
        {
            accTrailLeft.SetActive(false);
            accTrailRight.SetActive(false);
        }

        if (playerInput.IsBoosting && !SoccerManager.instance.CanMove)
        {
            preBoostTrail.SetActive(true);
        }
        else
        {
            preBoostTrail.SetActive(false);
        }

        if (SoccerManager.instance.CanMove)
        {
            rb.velocity = ForwardVelocity() + RightVelocity() * driftForce;

            Steer(playerInput.SteerInput);

            if (playerInput.IsAccelerating) Accelerate(); else Decelerate();

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

    void Accelerate()
    {
        rb.AddForce(transform.up * speed);

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
            boostTrail.emitting = true;
        }
    }

    void NoBoost()
    {
        isBoosting = false;

        boostTrail.emitting = false;
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
