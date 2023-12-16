using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Kaboom : MonoBehaviour
{
    PlayerCustomization me;
    public float collisionIntensityThreshold;

    [SerializeField] GameObject kaboom;

    public static event System.Action OnKaboom;

    private void Start()
    {
        me = GetComponent<PlayerCustomization>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            var hit = collision.gameObject.GetComponent<PlayerCustomization>();

            if (hit.isBlueTeam && me.isBlueTeam)
            {
                // Do Nothing
            }
            else
            {
                float collisionIntensity = collision.relativeVelocity.magnitude;

                if (collisionIntensity >= collisionIntensityThreshold)
                {
                    // Calculate the speeds of the two players
                    float mySpeed = me.GetComponent<Rigidbody2D>().velocity.magnitude;
                    float hitSpeed = hit.GetComponent<Rigidbody2D>().velocity.magnitude;

                    // Determine the winner based on speed
                    if (mySpeed >= hitSpeed)
                    {
                        Instantiate(kaboom, hit.transform.position, hit.transform.rotation);

                        if (collision.gameObject == SoccerManager.instance.blue1Instance)
                        {
                            SoccerManager.instance.blue1Instance = null;
                        }
                        if (collision.gameObject == SoccerManager.instance.red1Instance)
                        {
                            SoccerManager.instance.red1Instance = null;
                        }

                        Destroy(collision.gameObject);

                        OnKaboom?.Invoke();
                    }
                    else
                    {
                        Instantiate(kaboom, transform.position, transform.rotation);

                        Destroy(gameObject);

                        OnKaboom?.Invoke();
                    }
                }
            }
        }
    }
}
