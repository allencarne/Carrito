using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] AudioSource wallHit;
    [SerializeField] AudioSource GoalCheer;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] CircleCollider2D circleCollider;

    [SerializeField] CarOptions blueCarOptions;
    [SerializeField] CarOptions redCarOptions;
    private const string PLAYERPREFS_PREFIX = "PlayerCustomization_";

    [SerializeField] TrailRenderer trail;
    [SerializeField] float trailSpeed;
    [SerializeField] GameObject hitBallParticle;
    [SerializeField] AudioSource hitBallSound;
    bool canPlaySound = true;

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

            if (canPlaySound)
            {
                canPlaySound = false;

                hitBallSound.Play();
                Instantiate(hitBallParticle, transform.position, transform.rotation);
            }
        }
        else
        {
            canPlaySound = true;

            trail.emitting = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Car"))
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

                GoalCheer.Play();

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

            GoalCheer.Play();

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
        if (whoTouchedTheBallLastRed != null)
        {
            if (whoTouchedTheBallLastRed.GetComponent<PlayerCustomization>().isAI)
            {
                RandomExplosion(collision);
            }
            else
            {
                InstantiateExplosion(redCarOptions, PLAYERPREFS_PREFIX + "Red_", collision.transform.position, collision.transform.rotation);
            }
        }
        else
        {
            if (SoccerManager.instance.red1Instance)
            {
                if (SoccerManager.instance.red1Instance.GetComponent<PlayerCustomization>().isAI)
                {
                    RandomExplosion(collision);
                }
                else
                {
                    InstantiateExplosion(redCarOptions, PLAYERPREFS_PREFIX + "Red_", collision.transform.position, collision.transform.rotation);
                }
            }
            else
            {
                if (SoccerManager.instance.blue1Instance)
                {
                    if (SoccerManager.instance.blue1Instance.GetComponent<PlayerCustomization>().isAI)
                    {
                        RandomExplosion(collision);
                    }
                    else
                    {
                        InstantiateExplosion(blueCarOptions, PLAYERPREFS_PREFIX + "Blue_", collision.transform.position, collision.transform.rotation);
                    }
                }
            }
        }
    }

    void RedGoal(Collider2D collision)
    {
        if (whoTouchedTheBallLastBlue != null)
        {
            if (whoTouchedTheBallLastBlue.GetComponent<PlayerCustomization>().isAI)
            {
                RandomExplosion(collision);
            }
            else
            {
                InstantiateExplosion(blueCarOptions, PLAYERPREFS_PREFIX + "Blue_", collision.transform.position, collision.transform.rotation);
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

    void RandomExplosion(Collider2D collision)
    {
        int randomExplosion = Random.Range(0, blueCarOptions.explosions.Length);
        GameObject explosionObject = Instantiate(blueCarOptions.explosions[randomExplosion], collision.transform.position, collision.transform.rotation);

        // Get the Particle System component
        ParticleSystem explosionParticleSystem = explosionObject.GetComponent<ParticleSystem>();

        // Check if the Particle System component is not null
        if (explosionParticleSystem != null && blueCarOptions.trailColor.Length > 0)
        {
            // Select a random color index from blueCarOptions.trailColor
            int randomColorIndex = Random.Range(0, blueCarOptions.trailColor.Length);

            // Get the main module of the Particle System
            var mainModule = explosionParticleSystem.main;

            // Set the start color to the randomly selected color in the gradient
            mainModule.startColor = blueCarOptions.trailColor[randomColorIndex];
        }

        Destroy(explosionObject, 3);
    }

    private void InstantiateExplosion(CarOptions carOptions, string playerPrefsPrefix, Vector3 position, Quaternion rotation)
    {
        int explosionIndex = PlayerPrefs.GetInt(playerPrefsPrefix + "ExplosionIndex", 0);
        int explosionColorIndex = PlayerPrefs.GetInt(playerPrefsPrefix + "ExplosionColorIndex", 0);

        GameObject explosionObject = Instantiate(carOptions.explosions[explosionIndex], position, rotation);

        // Get the Particle System component
        ParticleSystem explosionParticleSystem = explosionObject.GetComponent<ParticleSystem>();

        // Check if the Particle System component is not null and carOptions.trailColor is not empty
        if (explosionParticleSystem != null && carOptions.trailColor.Length > 0)
        {
            // Ensure explosionColorIndex is within the bounds of carOptions.trailColor
            explosionColorIndex = Mathf.Clamp(explosionColorIndex, 0, carOptions.trailColor.Length - 1);

            // Get the main module of the Particle System
            var mainModule = explosionParticleSystem.main;

            // Set the start color to the specified color in carOptions.trailColor
            mainModule.startColor = carOptions.trailColor[explosionColorIndex];
        }

        Destroy(explosionObject, 3);
    }
}
