using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    PlayerControls playerControls;

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

    InputAction _Steer;
    InputAction _Accelerate;
    InputAction _Break;
    InputAction _Boost;
    InputAction _Drift;

    Vector2 steerInput;
    bool isAccelerating = false;
    bool isBreaking = false;
    bool isBoosting = false;
    bool isDrifting = false;

    private void OnEnable()
    {
        _Steer = playerControls.Player.Steer;
        _Steer.Enable();
        _Steer.performed += ctx => steerInput = ctx.ReadValue<Vector2>();

        _Accelerate = playerControls.Player.Accelerate;
        _Accelerate.Enable();
        _Accelerate.started += ctx => isAccelerating = true;
        _Accelerate.canceled += ctx => isAccelerating = false;

        _Break = playerControls.Player.Break;
        _Break.Enable();
        _Break.started += ctx => isBreaking = true;
        _Break.canceled += ctx => isBreaking = false;

        _Boost = playerControls.Player.Boost;
        _Boost.Enable();
        _Boost.started += ctx => isBoosting = true;
        _Boost.canceled += ctx => isBoosting = false;

        _Drift = playerControls.Player.Drift;
        _Drift.Enable();
        _Drift.started += ctx => isDrifting = true;
        _Drift.canceled += ctx => isDrifting = false;
    }

    private void OnDisable()
    {
        _Steer.Disable();
        _Accelerate.Disable();
        _Break.Disable();
        _Boost.Disable();
        _Drift.Disable();
    }

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void FixedUpdate()
    {
        rb.velocity = ForwardVelocity() + RightVelocity() * driftForce;

        Steer(steerInput);

        if (isAccelerating)
        {
            Accelerate();
        }
        else
        {
            Decelerate();
        }

        if (isBreaking)
        {
            Break();
        }

        if (isBoosting)
        {
            Boost();
        }
        else
        {
            NoBoost();
        }

        if (isDrifting)
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
        if (!_Steer.phase.IsInProgress())
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
