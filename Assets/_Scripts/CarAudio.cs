using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudio : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource carEngine;
    public AudioSource carDrift;
    public AudioSource carBoost;
    public AudioClip carBoostClip;

    [SerializeField] AudioSource carHitWall;
    [SerializeField] AudioSource carHitBall;
    [SerializeField] AudioSource carHitCar;

    private bool isBoostSoundPlaying = false;

    // Local Variable
    float desiredEnginePitch = 0.5f;
    float tireScreechPitch = 0.5f;

    Player player;
    SoccerAI soccerAI;

    float velocityMagnitude;

    private void Awake()
    {
        player = GetComponent<Player>();

        soccerAI = GetComponent<SoccerAI>();
    }

    private void Update()
    {
        UpdateEngineSFX();
        UpdateTireScreechingSFX();
        UpdateBoostSFX();
    }

    void UpdateEngineSFX()
    {
        //Handle Engine SFX
        if (player)
        {
            velocityMagnitude = player.GetVelocityMagnitude();
        }
        else if (soccerAI)
        {
            velocityMagnitude = soccerAI.GetVelocityMagnitude();
        }

        //Increase the engine volume as the car goes faster
        float desiredEngineVolume = velocityMagnitude * 0.5f;

        //But keep a miminum level so it plays even if the car is idle
        desiredEngineVolume = Mathf.Clamp(desiredEngineVolume, 0.2f, 1.0f);

        carEngine.volume = Mathf.Lerp(carEngine.volume, desiredEngineVolume, Time.deltaTime * 10);

        //To add more variation to the engine sound we also change the pitch
        desiredEnginePitch = velocityMagnitude * 0.2f;
        desiredEnginePitch = Mathf.Clamp(desiredEnginePitch, 0.5f, 2f);
        carEngine.pitch = Mathf.Lerp(carEngine.pitch, desiredEnginePitch, Time.deltaTime * 1.5f);
    }

    void UpdateTireScreechingSFX()
    {
        // Player
        if (player && player.isDrifting)
        {
            carDrift.volume = Mathf.Lerp(carDrift.volume, 1.0f, Time.deltaTime * 10);
            tireScreechPitch = Mathf.Lerp(tireScreechPitch, 0.5f, Time.deltaTime * 10);
        }
        else
        {
            carDrift.volume = Mathf.Lerp(carDrift.volume, 0, Time.deltaTime * 10);
        }

        // AI
        if (soccerAI && soccerAI.inputDrift)
        {
            carDrift.volume = Mathf.Lerp(carDrift.volume, 1.0f, Time.deltaTime * 10);
            tireScreechPitch = Mathf.Lerp(tireScreechPitch, 0.5f, Time.deltaTime * 10);
        }
        else
        {
            carDrift.volume = Mathf.Lerp(carDrift.volume, 0, Time.deltaTime * 10);
        }
    }

    void UpdateBoostSFX()
    {
        carBoost.pitch = Random.Range(0.80f, 1.05f);

        if (player)
        {
            if (player.isBoosting)
            {
                if (!isBoostSoundPlaying)
                {
                    carBoost.pitch = Random.Range(0.80f, 1.05f);
                    carBoost.Play();
                    isBoostSoundPlaying = true;
                }
            }
            else
            {
                if (isBoostSoundPlaying)
                {
                    carBoost.Stop();
                    isBoostSoundPlaying = false;
                }
            }
        }

        if (SoccerManager.instance.gameState == SoccerManager.GameState.Playing)
        {
            if (soccerAI)
            {
                if (soccerAI.inputBoost)
                {
                    if (!isBoostSoundPlaying)
                    {
                        carBoost.pitch = Random.Range(0.80f, 1.05f);
                        carBoost.Play();
                        isBoostSoundPlaying = true;
                    }
                }
                else
                {
                    if (isBoostSoundPlaying)
                    {
                        carBoost.Stop();
                        isBoostSoundPlaying = false;
                    }
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            carHitBall.Play();
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            carHitWall.Play();
        }

        if (collision.gameObject.CompareTag("Car"))
        {
            carHitCar.Play();
        }
    }
}
