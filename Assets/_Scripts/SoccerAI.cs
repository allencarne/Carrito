using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class SoccerAI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject attackingSide;
    [SerializeField] GameObject defendingSide;

    [Header("Trails")]
    [SerializeField] TrailRenderer leftAccelerateTrail;
    [SerializeField] TrailRenderer rightAccelerateTrail;
    [SerializeField] TrailRenderer leftDriftTrail;
    [SerializeField] TrailRenderer rightDriftTrail;
    [SerializeField] TrailRenderer boostTrail;

    [Header("Variables")]
    public float turnSpeed;
    //bool isAttacking = true;
    //bool isDefending = false;

    [Header("Stats")]
    float speed = 10;
    float torque = -350;
    float boostForce = 0.3f;
    float driftForce = 0.1f;
    public float currentBoost;
    [HideInInspector] public float maxBoost = 100;

    [Header("Input Variables")]
    [SerializeField] float inputTorque;
    [SerializeField] bool inputAccelerate;
    [SerializeField] bool inputBrakes;
    [SerializeField] bool inputBoost;
    [SerializeField] bool inputDrift;


    enum AIState 
    { 
        Attack,
        Defend
    }

    AIState state = AIState.Attack;

    private void Update()
    {
        switch (state)
        {
            case AIState.Attack:
                AttackState();
                break;
            case AIState.Defend:
                DefendState();
                break;
        }
    }

    void AttackState()
    {
        inputAccelerate = true;

        GameObject ball = SoccerManager.instance.ballInstance;

        if (ball != null)
        {
            Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();

            if (ballRb != null)
            {
                // Calculate direction from AI to the ball
                Vector2 vectorToTarget = ballRb.position - rb.position;
                vectorToTarget.Normalize();

                float angleToTarget = Vector2.SignedAngle(transform.up, vectorToTarget);
                angleToTarget *= -1;

                // Calculate the torque input based on the angle
                inputTorque = angleToTarget / turnSpeed;

                // Adjust the inputTorque to ensure it's within a reasonable range
                inputTorque = Mathf.Clamp(inputTorque, -1f, 1f);

                // Debug.Log("Angle to Ball: " + angleToTarget);
            }
            else
            {
                Debug.LogWarning("Ball does not have a Rigidbody2D component.");
            }
        }
    }

    void DefendState()
    {

    }

    private void FixedUpdate()
    {
        rb.velocity = ForwardVelocity() + RightVelocity() * driftForce;

        Steer(inputTorque);

        if (inputAccelerate) Accelerate(); else Decelerate();

        if (inputBrakes) Break();

        if (inputBoost) Boost(); else NoBoost();

        if (currentBoost <= 0) NoBoost();

        if (inputDrift) Drift(); else NoDrift();
    }

    void Steer(float inputValue)
    {
        rb.angularVelocity = inputValue * torque;
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
