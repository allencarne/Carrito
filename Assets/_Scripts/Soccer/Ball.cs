using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] CircleCollider2D circleCollider;

    [SerializeField] GameObject explosionPrefab;
    [SerializeField] TrailRenderer trail;
    [SerializeField] float trailSpeed;

    public bool blueSide;
    public bool redSide;

    [SerializeField] GameObject whoTouchedTheBallLastBlue;
    [SerializeField] GameObject whoTouchedTheBallLastRed;
    public static event System.Action OnScored;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            if (collision.gameObject == SoccerManager.instance.blue1Instance)
            {
                whoTouchedTheBallLastBlue = collision.gameObject;
            }

            if (collision.gameObject == SoccerManager.instance.blue2Instance)
            {
                whoTouchedTheBallLastBlue = collision.gameObject;
            }

            if (collision.gameObject == SoccerManager.instance.blue3Instance)
            {
                whoTouchedTheBallLastBlue = collision.gameObject;
            }


            if (collision.gameObject == SoccerManager.instance.red1Instance)
            {
                whoTouchedTheBallLastRed = collision.gameObject;
            }

            if (collision.gameObject == SoccerManager.instance.red2Instance)
            {
                whoTouchedTheBallLastRed = collision.gameObject;
            }

            if (collision.gameObject == SoccerManager.instance.red3Instance)
            {
                whoTouchedTheBallLastRed = collision.gameObject;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Blue Goal"))
        {
            StartCoroutine(ScoreDelay(collision));

            SoccerManager.instance.redScore += 1;

            OnScored?.Invoke();

            GameObject cameraController = GameObject.Find("Camera Controller");
            if (cameraController != null)
            {
                cameraController.GetComponent<CameraFollowAndZoom>().target = whoTouchedTheBallLastRed.transform;
            }
        }

        if (collision.CompareTag("Red Goal"))
        {
            StartCoroutine(ScoreDelay(collision));

            SoccerManager.instance.blueScore += 1;

            OnScored?.Invoke();

            GameObject cameraController = GameObject.Find("Camera Controller");
            if (cameraController != null)
            {
                cameraController.GetComponent<CameraFollowAndZoom>().target = whoTouchedTheBallLastBlue.transform;
            }
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

    IEnumerator ScoreDelay(Collider2D collision)
    {
        var explosion = Instantiate(explosionPrefab, collision.transform.position, collision.transform.rotation);

        spriteRenderer.enabled = false;
        circleCollider.enabled = false;

        yield return new WaitForSeconds(3);

        Destroy(explosion);

        switch (SoccerManager.instance.gameMode)
        {
            case SoccerManager.GameMode.FreePlay:
                SceneManager.LoadScene("Soccer");
                break;
            case SoccerManager.GameMode.Training:
                break;
            case SoccerManager.GameMode.OneVsOne:
                SoccerManager.instance.gameState = SoccerManager.GameState.GoalScored;
                break;
            case SoccerManager.GameMode.TwoVsTwo:
                break;
            case SoccerManager.GameMode.ThreeVsThree:
                break;
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
