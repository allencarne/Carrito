using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class SoccerAI : MonoBehaviour
{
    [SerializeField] bool BlueSide;

    [Header("Components")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject attackingSide;
    [SerializeField] GameObject defendingSide;
    GameObject ball;
    Rigidbody2D ballRB;

    [Header("Trails")]
    [SerializeField] TrailRenderer leftAccelerateTrail;
    [SerializeField] TrailRenderer rightAccelerateTrail;
    [SerializeField] TrailRenderer leftDriftTrail;
    [SerializeField] TrailRenderer rightDriftTrail;
    [SerializeField] TrailRenderer boostTrail;

    [Header("Stats")]
    float speed = 10;
    float turnSpeed = 5;
    float torque = -350;
    float boostForce = 0.3f;
    float driftForce = 0.1f;
    public float currentBoost;
    [HideInInspector] public float maxBoost = 100;

    [Header("Input Variables")]
    float inputTorque;
    bool inputAccelerate;
    bool inputBrakes;
    bool inputBoost;
    bool inputDrift;

    [SerializeField] float boostThresholdDistance;

    enum AIState 
    { 
        Attack,
        Defend
    }

    AIState state = AIState.Attack;

    private void Update()
    {
        if (ball == null)
        {
            if (SoccerManager.instance.ballInstance != null)
            {
                ball = SoccerManager.instance.ballInstance;
                ballRB = ball.GetComponent<Rigidbody2D>();
            }
        }

        switch (state)
        {
            case AIState.Attack:
                AttackState();
                break;
            case AIState.Defend:
                DefendState();
                break;
        }

        // If blue side - if on left side of ball (behind it) - Then position car in a way that allows us to score a goal
        if (ball != null && ballRB != null)
        {
            if (BlueSide)
            {
                if (transform.position.x < ball.transform.position.x)
                {
                    Debug.Log("AI is on LEFT of Ball");

                    state = AIState.Attack;
                }

                if (transform.position.x > ball.transform.position.x)
                {
                    Debug.Log("AI is on RIGHT of Ball");

                    state = AIState.Defend;
                }
            }
            else
            {
                if (transform.position.x < ball.transform.position.x)
                {
                    Debug.Log("AI is on LEFT of Ball");

                    state = AIState.Defend;
                }

                if (transform.position.x > ball.transform.position.x)
                {
                    Debug.Log("AI is on RIGHT of Ball");

                    state = AIState.Attack;
                }
            }
        }
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

    void AttackState()
    {
        inputAccelerate = true;

        ChaseBall();
        BoostIfFarAway();
    }

    void DefendState()
    {

    }

    void ChaseBall()
    {
        if (ball != null && ballRB != null)
        {
            // Calculate direction from AI to the ball
            Vector2 vectorToTarget = ballRB.position - rb.position;
            vectorToTarget.Normalize();

            float angleToTarget = Vector2.SignedAngle(transform.up, vectorToTarget);
            angleToTarget *= -1;

            // Calculate the torque input based on the angle
            inputTorque = angleToTarget / turnSpeed;

            // Adjust the inputTorque to ensure it's within a reasonable range
            inputTorque = Mathf.Clamp(inputTorque, -1f, 1f);

            // Debug.Log("Angle to Ball: " + angleToTarget);
        }
    }

    void BoostIfFarAway()
    {
        if (ball != null && ballRB != null)
        {
            Vector2 vectorToTarget = ballRB.position - rb.position;

            float distanceToTarget = vectorToTarget.magnitude;

            if (distanceToTarget > boostThresholdDistance)
            {
                inputBoost = true;
            }
            else
            {
                inputBoost = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, boostThresholdDistance);
    }

    #region Input

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

    #endregion
}
