using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] TrailRenderer trail;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] GameObject explosionPrefab;

    [SerializeField] float trailSpeed;

    public bool blueSide;
    public bool redSide;

    private void Update()
    {
        float ballSpeed = rb.velocity.magnitude;

        if (ballSpeed > trailSpeed)
        {
            trail.emitting = true;
        }
        else
        {
            trail.emitting = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Blue Goal"))
        {
            var explosion = Instantiate(explosionPrefab, collision.transform.position, collision.transform.rotation);

            Destroy(explosion, 2f);

            //SceneManager.LoadScene(0);
        }

        if (collision.CompareTag("Red Goal"))
        {
            var explosion = Instantiate(explosionPrefab, collision.transform.position, collision.transform.rotation);

            Destroy(explosion, 2f);

            //SceneManager.LoadScene(0);
        }

        if (collision.CompareTag("Blue Side"))
        {
            blueSide = true;
        }

        if (collision.CompareTag("Red Side"))
        {
            redSide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Blue Side"))
        {
            blueSide = false;
        }

        if (collision.CompareTag("Red Side"))
        {
            redSide = false;
        }
    }
}
