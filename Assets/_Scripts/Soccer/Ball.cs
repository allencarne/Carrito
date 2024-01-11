using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] AudioSource wallHit;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] CircleCollider2D circleCollider;

    [SerializeField] CarOptions blueCarOptions;
    [SerializeField] CarOptions redCarOptions;
    private const string PLAYERPREFS_PREFIX = "PlayerCustomization_";

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
        if (collision.gameObject.CompareTag("Wall"))
        {
            wallHit.Play();
        }

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

                SoccerManager.instance.GetComponent<SoccerTraining>().ReloadTrainingLevel();
                StartCoroutine(SoccerManager.instance.TrainingEndDelay());
            }
            else
            {
                StartCoroutine(ScoreDelay());
                BlueGoal(collision);

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

                        if (SoccerManager.instance.blue1Instance)
                        {
                            cameraController.GetComponent<CameraFollowAndZoom>().target = SoccerManager.instance.blue1Instance.transform;
                        }
                    }
                }
            }
        }

        if (collision.CompareTag("Red Goal"))
        {
            StartCoroutine(ScoreDelay());
            RedGoal(collision);

            if (SoccerManager.instance.gameMode == SoccerManager.GameMode.Training)
            {
                SoccerManager.instance.trainingText.color = Color.green;
                SoccerManager.instance.trainingText.text = "Passed!";
                SoccerManager.instance.trainingText.gameObject.SetActive(true);

                SoccerManager.instance.GetComponent<SoccerTraining>().UpdateBubble();
                SoccerManager.instance.GetComponent<SoccerTraining>().ResetState();

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

    void BlueGoal(Collider2D collision)
    {
        int explosionIndex;

        if (whoTouchedTheBallLastRed != null)
        {
            if (whoTouchedTheBallLastRed.GetComponent<PlayerCustomization>().isAI)
            {
                // Instatiate a Random Explosion
                int randomExplosion = Random.Range(0, redCarOptions.explosions.Length);
                var explosion = Instantiate(redCarOptions.explosions[randomExplosion], collision.transform.position, collision.transform.rotation);
                Destroy(explosion, 3);
            }
            else
            {
                // Instatiate Explosion Based on Red Player Prefs
                explosionIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + "Red_" + "ExplosionIndex", 0);
                var explosion = Instantiate(redCarOptions.explosions[explosionIndex], collision.transform.position, collision.transform.rotation);
                Destroy(explosion, 3);
            }
        }
        else
        {
            if (SoccerManager.instance.red1Instance)
            {
                if (SoccerManager.instance.red1Instance.GetComponent<PlayerCustomization>().isAI)
                {
                    // Instatiate a Random Explosion
                    int randomExplosion = Random.Range(0, redCarOptions.explosions.Length);
                    var explosion = Instantiate(redCarOptions.explosions[randomExplosion], collision.transform.position, collision.transform.rotation);
                    Destroy(explosion, 3);
                }
                else
                {
                    // Instatiate Explosion Based on Red Player Prefs
                    explosionIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + "Red_" + "ExplosionIndex", 0);
                    var explosion = Instantiate(redCarOptions.explosions[explosionIndex], collision.transform.position, collision.transform.rotation);
                    Destroy(explosion, 3);
                }
            }
            else
            {
                if (SoccerManager.instance.blue1Instance)
                {
                    if (SoccerManager.instance.blue1Instance.GetComponent<PlayerCustomization>().isAI)
                    {
                        // Instatiate a Random Explosion
                        int randomExplosion = Random.Range(0, blueCarOptions.explosions.Length);
                        var explosion = Instantiate(blueCarOptions.explosions[randomExplosion], collision.transform.position, collision.transform.rotation);
                        Destroy(explosion, 3);
                    }
                    else
                    {
                        // Instatiate Explosion Based on Blue Player Prefs
                        explosionIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + "Blue_" + "ExplosionIndex", 0);
                        var explosion = Instantiate(blueCarOptions.explosions[explosionIndex], collision.transform.position, collision.transform.rotation);
                        Destroy(explosion, 3);
                    }
                }
            }
        }
    }

    void RedGoal(Collider2D collision)
    {
        int explosionIndex;

        if (whoTouchedTheBallLastBlue != null)
        {
            if (whoTouchedTheBallLastBlue.GetComponent<PlayerCustomization>().isAI)
            {
                // Instatiate a Random Explosion
                int randomExplosion = Random.Range(0, redCarOptions.explosions.Length);
                var explosion = Instantiate(redCarOptions.explosions[randomExplosion], collision.transform.position, collision.transform.rotation);
                Destroy(explosion, 3);
            }
            else
            {
                explosionIndex = PlayerPrefs.GetInt(PLAYERPREFS_PREFIX + "Blue_" + "ExplosionIndex", 0);

                var explosion = Instantiate(blueCarOptions.explosions[explosionIndex], collision.transform.position, collision.transform.rotation);

                Destroy(explosion, 3);
            }
        }
    }


    IEnumerator ScoreDelay()
    {
        spriteRenderer.enabled = false;
        circleCollider.enabled = false;

        yield return new WaitForSeconds(3);

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
}
