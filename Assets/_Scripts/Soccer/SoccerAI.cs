using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoccerAI : MonoBehaviour
{
    [SerializeField] bool BlueSide;

    [SerializeField] CarOptions carOptions;

    [Header("Components")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject attackingSide;
    [SerializeField] GameObject defendingSide;
    GameObject ball;
    Rigidbody2D ballRB;
    Transform blueDefensePoint;
    Transform redDefensePoint;

    [Header("Trails")]
    [SerializeField] TrailRenderer leftAccelerateTrail;
    [SerializeField] TrailRenderer rightAccelerateTrail;
    [SerializeField] TrailRenderer leftDriftTrail;
    [SerializeField] TrailRenderer rightDriftTrail;
    [SerializeField] ParticleSystem boostTrail;
    private ParticleSystem.ColorOverLifetimeModule colorOverLifetimeModule;

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
    public bool inputBoost;
    public bool inputDrift;

    [SerializeField] float boostThresholdDistance;
    float previousBallX;

    enum AIState 
    { 
        Attack,
        Defend
    }

    AIState state = AIState.Attack;

    private void Awake()
    {
        blueDefensePoint = GameObject.Find("Blue Defense Point").transform;
        redDefensePoint = GameObject.Find("Red Defense Point").transform;
    }

    private void Start()
    {
        if (carOptions.trails.Length > 0 && carOptions.trailColor.Length > 0)
        {
            int randomTrailIndex = Random.Range(0, carOptions.trails.Length);
            int randomColorIndex = Random.Range(0, carOptions.trailColor.Length);

            // Instantiate the Particle System prefab
            ParticleSystem instantiatedTrail = Instantiate(carOptions.trails[randomTrailIndex], transform.position, transform.rotation, transform);

            // Assign the instantiated Particle System to boostTrail
            boostTrail = instantiatedTrail;

            // Assign a random color to the boostTrail
            colorOverLifetimeModule = instantiatedTrail.colorOverLifetime;
            colorOverLifetimeModule.color = carOptions.trailColor[randomColorIndex];
        }
    }

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
            bool isOnLeft = transform.position.x < ball.transform.position.x;

            if ((BlueSide && isOnLeft) || (!BlueSide && !isOnLeft))
            {
                //Debug.Log("AI is on LEFT of Ball");
                state = AIState.Attack;
            }
            else
            {
                //Debug.Log("AI is on RIGHT of Ball");
                state = AIState.Defend;
            }
        }
    }

    private void FixedUpdate()
    {
        if (SoccerManager.instance.CanMove)
        {
            rb.velocity = ForwardVelocity() + RightVelocity() * driftForce;

            Steer(inputTorque);

            if (inputAccelerate) Accelerate(); else Decelerate();

            if (inputBrakes) Break();

            if (inputBoost) Boost(); else NoBoost();

            if (currentBoost <= 0) NoBoost();

            if (inputDrift) Drift(); else NoDrift();
        }
    }

    void AttackState()
    {
        inputAccelerate = true;

        MoteToBall();
        BoostIfFarAway();
    }

    void DefendState()
    {
        MoveToGoal();
    }

    void MoteToBall()
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

    void MoveToGoal()
    {
        if (BlueSide)
        {
            // Calculate direction from AI to the ball
            Vector2 vectorToTarget = blueDefensePoint.position - transform.position;
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
            // Calculate direction from AI to the ball
            Vector2 vectorToTarget = redDefensePoint.position - transform.position;
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

    void MovingTowardGoal()
    {
        if (ball != null && ballRB != null)
        {
            // Check if the ball is moving towards or away from the goal
            bool isMovingTowardsGoal = ballRB.position.x > previousBallX;

            // Update the previousBallX for the next frame
            previousBallX = ballRB.position.x;

            // Use isMovingTowardsGoal as needed in your logic
            if (isMovingTowardsGoal)
            {
                Debug.Log("Ball is moving towards the goal");
            }
            else
            {
                Debug.Log("Ball is moving away from the goal");
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

            //boostTrail.SetActive(true);

            
            if (!boostTrail.isEmitting)
            {
                boostTrail.Play();
            }
            
        }
    }

    void NoBoost()
    {
        //boostTrail.SetActive(false);

        
        if (boostTrail.isEmitting)
        {
            boostTrail.Stop();
        }
        
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
