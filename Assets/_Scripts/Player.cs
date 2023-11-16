using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] Rigidbody2D rb;

    // Trails
    [SerializeField] TrailRenderer leftAccelerateTrail;
    [SerializeField] TrailRenderer rightAccelerateTrail;
    [SerializeField] TrailRenderer leftDriftTrail;
    [SerializeField] TrailRenderer rightDriftTrail;
    [SerializeField] TrailRenderer boostTrail;

    [SerializeField] float speed;
    [SerializeField] float torque;
    [SerializeField] float boostForce;
    [SerializeField] float driftForce;

    public float currentBoost;
    public float maxBoost;

    private void FixedUpdate()
    {
        rb.velocity = ForwardVelocity() + RightVelocity() * driftForce;

        Steer(playerInput.SteerInput);

        if (playerInput.IsAccelerating)
        {
            Accelerate();
        }
        else
        {
            Decelerate();
        }

        if (playerInput.IsBreaking)
        {
            Break();
        }

        if (playerInput.IsBoosting)
        {
            Boost();
        }
        else
        {
            NoBoost();
        }

        if (currentBoost <= 0)
        {
            NoBoost();
        }

        if (playerInput.IsDrifting)
        {
            Drift();
        }
        else
        {
            NoDrift();
        }
    }

    void Steer(Vector2 inputValue)
    {
        // Assuming you want to use only the horizontal component for angular velocity
        float horizontalInput = inputValue.x;

        // Apply steering based on the horizontal input
        rb.angularVelocity = horizontalInput * torque;

        // If the input is not currently being performed, stop turning
        if (!playerInput._Steer.phase.IsInProgress())
        {
            rb.angularVelocity = 0f;
        }
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
            currentBoost--;
            //gameManager.SetBoost(currentBoost);
            rb.AddForce(transform.up * boostForce);
            rb.AddForce(transform.up * boostForce, ForceMode2D.Impulse);
            boostTrail.emitting = true;
        }
    }

    void NoBoost()
    {
        boostTrail.emitting = false;
    }

    void Drift()
    {
        driftForce = 1f;
        leftDriftTrail.emitting = true;
        rightDriftTrail.emitting = true;
    }

    void NoDrift()
    {
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
