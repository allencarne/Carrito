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
            if (SoccerManager.instance.gameMode == SoccerManager.GameMode.Training)
            {
                Time.timeScale = 0;

                SoccerManager.instance.trainingText.color = Color.red;
                SoccerManager.instance.trainingText.text = "Failed!";
                SoccerManager.instance.trainingText.gameObject.SetActive(true);

                StartCoroutine(SoccerManager.instance.TrainingEndDelay());
            }
            else
            {
                StartCoroutine(ScoreDelay(collision));

                SoccerManager.instance.redScore += 1;

                OnScored?.Invoke();

                GameObject cameraController = GameObject.Find("Camera Controller");
                if (cameraController != null)
                {
                    if (whoTouchedTheBallLastRed != null)
                    {
                        cameraController.GetComponent<CameraFollowAndZoom>().target = whoTouchedTheBallLastRed.transform;
                    }
                    else
                    {
                        if (SoccerManager.instance.red1Instance)
                        {
                            cameraController.GetComponent<CameraFollowAndZoom>().target = SoccerManager.instance.red1Instance.transform;
                        }
                    }
                }
            }
        }

        if (collision.CompareTag("Red Goal"))
        {
            StartCoroutine(ScoreDelay(collision));

            if (SoccerManager.instance.gameMode == SoccerManager.GameMode.Training)
            {
                SoccerManager.instance.trainingText.color = Color.green;
                SoccerManager.instance.trainingText.text = "Passed!";
                SoccerManager.instance.trainingText.gameObject.SetActive(true);

                UpdateBubble();

                StartCoroutine(SoccerManager.instance.TrainingEndDelay());
            }
            else
            {
                SoccerManager.instance.blueScore += 1;
            }

            OnScored?.Invoke();

            GameObject cameraController = GameObject.Find("Camera Controller");
            if (cameraController != null)
            {
                if (whoTouchedTheBallLastBlue != null)
                {
                    cameraController.GetComponent<CameraFollowAndZoom>().target = whoTouchedTheBallLastBlue.transform;
                }
                else
                {
                    if (SoccerManager.instance.blue1Instance)
                    {
                        cameraController.GetComponent<CameraFollowAndZoom>().target = SoccerManager.instance.blue1Instance.transform;
                    }
                }
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
                SoccerManager.instance.gameState = SoccerManager.GameState.GoalScored;
                break;
            case SoccerManager.GameMode.ThreeVsThree:
                SoccerManager.instance.gameState = SoccerManager.GameState.GoalScored;
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

    void UpdateBubble()
    {
        SoccerTraining soccerTraining = SoccerManager.instance.GetComponent<SoccerTraining>();

        switch (soccerTraining.training)
        {
            case SoccerTraining.Training.Striker1:
                PlayerPrefs.SetInt("Striker1", 1);
                PlayerPrefs.Save();
                break;
            case SoccerTraining.Training.Striker2:
                PlayerPrefs.SetInt("Striker2", 1);
                PlayerPrefs.Save();
                break;
            case SoccerTraining.Training.Striker3:
                PlayerPrefs.SetInt("Striker3", 1);
                PlayerPrefs.Save();
                break;
            case SoccerTraining.Training.Striker4:
                PlayerPrefs.SetInt("Striker4", 1);
                PlayerPrefs.Save();
                break;
            case SoccerTraining.Training.Striker5:
                PlayerPrefs.SetInt("Striker5", 1);
                PlayerPrefs.Save();
                break;
            case SoccerTraining.Training.Striker6:
                PlayerPrefs.SetInt("Striker6", 1);
                PlayerPrefs.Save();
                break;
            case SoccerTraining.Training.Striker7:
                PlayerPrefs.SetInt("Striker7", 1);
                PlayerPrefs.Save();
                break;
            case SoccerTraining.Training.Striker8:
                PlayerPrefs.SetInt("Striker8", 1);
                PlayerPrefs.Save();
                break;
            case SoccerTraining.Training.Striker9:
                PlayerPrefs.SetInt("Striker9", 1);
                PlayerPrefs.Save();
                break;
            case SoccerTraining.Training.Striker10:
                PlayerPrefs.SetInt("Striker10", 1);
                PlayerPrefs.Save();
                break;
            case SoccerTraining.Training.Defender1:
                PlayerPrefs.SetInt("Defender1", 1);
                PlayerPrefs.Save();
                break;
            case SoccerTraining.Training.Defender2:
                PlayerPrefs.SetInt("Defender2", 1);
                PlayerPrefs.Save();
                break;
            case SoccerTraining.Training.Defender3:
                PlayerPrefs.SetInt("Defender3", 1);
                PlayerPrefs.Save();
                break;
            case SoccerTraining.Training.Defender4:
                PlayerPrefs.SetInt("Defender4", 1);
                PlayerPrefs.Save();
                break;
            case SoccerTraining.Training.Defender5:
                PlayerPrefs.SetInt("Defender5", 1);
                PlayerPrefs.Save();
                break;
            case SoccerTraining.Training.Defender6:
                PlayerPrefs.SetInt("Defender6", 1);
                PlayerPrefs.Save();
                break;
            case SoccerTraining.Training.Defender7:
                PlayerPrefs.SetInt("Defender7", 1);
                PlayerPrefs.Save();
                break;
            case SoccerTraining.Training.Defender8:
                PlayerPrefs.SetInt("Defender8", 1);
                PlayerPrefs.Save();
                break;
            case SoccerTraining.Training.Defender9:
                PlayerPrefs.SetInt("Defender9", 1);
                PlayerPrefs.Save();
                break;
            case SoccerTraining.Training.Defender10:
                PlayerPrefs.SetInt("Defender10", 1);
                PlayerPrefs.Save();
                break;
        }
    }
}
