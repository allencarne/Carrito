using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.InputSystem;
using System.Linq;
using System.Net.NetworkInformation;
using Unity.VisualScripting;

public class SoccerManager : MonoBehaviour
{
    #region Singleton

    public static SoccerManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than once instance of SoccerManager found!");
            return;
        }

        instance = this;

        // Retrieve the selected game mode from PlayerPrefs
        if (PlayerPrefs.HasKey("GameMode"))
        {
            gameMode = (GameMode)PlayerPrefs.GetInt("GameMode");
        }
    }

    #endregion

    [SerializeField] SpriteRenderer ground;
    [SerializeField] SpriteRenderer lines;

    [SerializeField] Color groundColorGreen;
    [SerializeField] Color lineColorGreen;

    [SerializeField] Color groundColorRed;
    [SerializeField] Color linesColorRed;

    [SerializeField] Color groundColorBlue;
    [SerializeField] Color linesColorBlue;

    [SerializeField] Color groundColorBlack;
    [SerializeField] Color linesColorBlack;

    [Header("Players")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject BlueAI;
    [SerializeField] GameObject RedAI;

    [Header("Instances")]
    public GameObject blue1Instance;
    public GameObject blue2Instance;
    public GameObject blue3Instance;
    public GameObject red1Instance;
    public GameObject red2Instance;
    public GameObject red3Instance;

    [Header("Ball")]
    [SerializeField] GameObject ball;
    public GameObject ballInstance;

    [Header("Spawns")]
    [SerializeField] Transform[] blueSpawnPoints;
    [SerializeField] Transform[] redSpawnPoints;
    [SerializeField] Transform ballSpawnPoint;

    // Count Down
    [SerializeField] TextMeshProUGUI countDownText;
    bool canCountDown = true;

    // Match Time
    [SerializeField] TextMeshProUGUI matchTimeText;
    float matchDurationInSeconds = 300f; // 5 minutes
    //float matchDurationInSeconds = 10f; // For Testing
    bool isCountdownInProgress = false;
    public bool CanMove = false;
    private bool isMatchPaused = false;
    bool isOvertime = false;

    // Score
    [SerializeField] TextMeshProUGUI blueScoreText;
    public int blueScore;
    [SerializeField] TextMeshProUGUI redScoreText;
    public int redScore;

    [SerializeField] GameObject pauseMenu;

    // Game Over
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI whoWonText;

    // Pause
    [SerializeField] InputActionAsset asset;
    InputAction pauseAction;
    public static event System.Action OnResumed;

    public enum PlayerType
    {
        None,
        AI,
        Player1,
        Player2,
        Player3,
        Player4,
        Player5,
        Player6,
    }

    PlayerType blue1PlayerType = PlayerType.None;
    PlayerType red1PlayerType = PlayerType.None;

    public enum GameState
    {
        CountDown,
        Playing,
        Paused,
        GoalScored,
        OverTime,
        GameOver,
    }

    public enum GameMode
    {
        FreePlay,
        Training,
        OneVsOne,
        TwoVsTwo,
        ThreeVsThree
    }

    public GameState gameState = GameState.CountDown;
    public GameMode gameMode = GameMode.FreePlay;

    enum MapType
    {
        Green,
        Blue,
        Red,
        Black,
    }

    private void OnEnable()
    {
        Kaboom.OnKaboom += KaboomHappened;

        pauseAction = asset.FindAction("Pause");
        pauseAction.Enable();
        pauseAction.performed += OnPause;
    }

    private void OnDisable()
    {
        Kaboom.OnKaboom -= KaboomHappened;

        pauseAction.performed -= OnPause;
        pauseAction.Disable();
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);

        // Check if the PlayerPrefs key exists
        if (PlayerPrefs.HasKey("SelectedMapType"))
        {
            // Retrieve the mapType from PlayerPrefs
            int mapTypeValue = PlayerPrefs.GetInt("SelectedMapType");

            // Check if the retrieved value is a valid MapType enum value
            if (Enum.IsDefined(typeof(MapType), mapTypeValue))
            {
                MapType mapType = (MapType)mapTypeValue;

                // Update colors based on the selected MapType
                switch (mapType)
                {
                    case MapType.Green:
                        ground.color = groundColorGreen;
                        lines.color = lineColorGreen;
                        break;

                    case MapType.Red:
                        ground.color = groundColorRed;
                        lines.color = linesColorRed;
                        break;

                    case MapType.Blue:
                        ground.color = groundColorBlue;
                        lines.color = linesColorBlue;
                        break;

                    case MapType.Black:
                        ground.color = groundColorBlack;
                        lines.color = linesColorBlack;
                        break;
                }
            }
            else
            {
                Debug.LogError("Invalid mapType value retrieved from PlayerPrefs.");
            }
        }
    }

    private void Update()
    {
        switch (gameState)
        {
            case GameState.CountDown:
                CountDownState();
                break;
            case GameState.Playing:
                PlayingState();
                break;
            case GameState.Paused:
                PausedState();
                break;
            case GameState.GoalScored:
                GoalScoredState();
                break;
            case GameState.OverTime:
                OverTimeState();
                break;
            case GameState.GameOver:
                GameOverState();
                break;
        }
    }

    void CountDownState()
    {
        Time.timeScale = 1;

        // Retrieve player types from PlayerPrefs
        blue1PlayerType = (PlayerType)Enum.Parse(typeof(PlayerType), PlayerPrefs.GetString("Blue1Type", PlayerType.None.ToString()));
        red1PlayerType = (PlayerType)Enum.Parse(typeof(PlayerType), PlayerPrefs.GetString("Red1Type", PlayerType.None.ToString()));

        switch (gameMode)
        {
            case GameMode.FreePlay:
                CountDown();
                SpawnBall();

                // Spawn Blue 1 Player
                if (blue1Instance == null)
                {
                    int randomSpawnIndex = UnityEngine.Random.Range(0, blueSpawnPoints.Length);
                    Transform selectedSpawnPoint = blueSpawnPoints[randomSpawnIndex];

                    blue1Instance = Instantiate(player, selectedSpawnPoint.position, selectedSpawnPoint.rotation);

                    // Assign to Blue
                    blue1Instance.GetComponent<PlayerCustomization>().isBlueTeam = true;
                }

                break;
            case GameMode.Training:
                CountDown();
                SpawnBall();
                break;
            case GameMode.OneVsOne:
                CountDown();
                SpawnBall();
                SpawnBlue1();
                SpawnRed1();

                break;
            case GameMode.TwoVsTwo:
                break;
            case GameMode.ThreeVsThree:
                break;
        }
    }

    void CountDown()
    {
        if (canCountDown)
        {
            canCountDown = false;

            countDownText.gameObject.SetActive(true);

            StartCoroutine(CountdownCoroutine());
        }
    }

    IEnumerator CountdownCoroutine()
    {
        countDownText.text = "3";
        yield return new WaitForSeconds(1f);

        countDownText.text = "2";
        yield return new WaitForSeconds(1f);

        countDownText.text = "1";
        yield return new WaitForSeconds(1f);

        countDownText.text = "Go!";
        yield return new WaitForSeconds(1f);

        // Do Stuff
        gameState = GameState.Playing;

        // Wait a second before turning off text
        countDownText.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
    }

    void PlayingState()
    {
        isMatchPaused = false;

        CanMove = true;

        if (!isCountdownInProgress && !isMatchPaused)
        {
            isCountdownInProgress = true;

            matchTimeText.gameObject.SetActive(true);

            StartCoroutine(MatchTimeCoroutine());
        }
    }

    IEnumerator MatchTimeCoroutine()
    {
        float timeRemaining = matchDurationInSeconds;

        while (timeRemaining > 0f)
        {
            if (!isMatchPaused)
            {
                // Update the minutes and seconds
                int minutes = Mathf.FloorToInt(timeRemaining / 60f);
                int seconds = Mathf.FloorToInt(timeRemaining % 60f);

                // Display the time
                matchTimeText.text = string.Format("{0}:{1:00}", minutes, seconds);

                yield return new WaitForSeconds(1f);

                // Decrement
                timeRemaining -= 1f;
            }
            else
            {
                // If the match is paused, wait for the next frame
                yield return null;
            }
        }

        // End of Match
        matchTimeText.gameObject.SetActive(false);

        if (blueScore == redScore)
        {
            gameState = GameState.OverTime;
        }
        else
        {
            gameState = GameState.GameOver;
        }
    }

    void PausedState()
    {
        pauseMenu.SetActive(true);

        Time.timeScale = 0f;
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (gameState == GameState.Playing)
            {
                gameState = GameState.Paused;
            }
            else if (gameState == GameState.Paused)
            {
                OnResumed?.Invoke();
            }
        }
    }

    void GoalScoredState()
    {
        isMatchPaused = true;

        blueScoreText.text = blueScore.ToString();
        redScoreText.text = redScore.ToString();

        Destroy(ballInstance);
        Destroy(blue1Instance);
        Destroy(red1Instance);

        canCountDown = true;
        CanMove = false;

        if (isOvertime)
        {
            isOvertime = false;

            gameState = GameState.GameOver;
        }
        else
        {
            gameState = GameState.CountDown;
        }
    }

    void OverTimeState()
    {
        isOvertime = true;
        matchTimeText.gameObject.SetActive(true);

        StartCoroutine(UpdateMatchTime());
    }

    IEnumerator UpdateMatchTime()
    {
        // Change text color to red
        matchTimeText.color = Color.red;

        float elapsedTime = 0f;

        while (isOvertime)
        {
            // Update the elapsed time
            elapsedTime += Time.deltaTime;

            // Calculate minutes and seconds
            int minutes = Mathf.FloorToInt(elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);

            // Display the time
            matchTimeText.text = string.Format("{0}:{1:00}", minutes, seconds);

            yield return null;
        }
    }

    void GameOverState()
    {
        Time.timeScale = 0;

        gameOverPanel.SetActive(true);

        if (blueScore > redScore)
        {
            whoWonText.color = Color.blue;
            whoWonText.text = "Blue Team Won!";
        }

        if (redScore > blueScore)
        {
            whoWonText.color = Color.red;
            whoWonText.text = "Red Team Won!";
        }
    }

    void SpawnBall()
    {
        if (ballInstance == null)
        {
            ballInstance = Instantiate(ball, ballSpawnPoint);
        }
    }

    void SpawnBlue1()
    {
        if (blue1Instance == null)
        {
            if (blue1PlayerType == PlayerType.AI)
            {
                int randomSpawnIndex = UnityEngine.Random.Range(0, blueSpawnPoints.Length);
                Transform selectedSpawnPoint = blueSpawnPoints[randomSpawnIndex];

                blue1Instance = Instantiate(BlueAI, selectedSpawnPoint.position, selectedSpawnPoint.rotation);

                // Assign to Blue
                blue1Instance.GetComponent<PlayerCustomization>().isBlueTeam = true;

                // Assign AI
                blue1Instance.GetComponent<PlayerCustomization>().isAI = true;
            }
            else
            {
                int randomSpawnIndex = UnityEngine.Random.Range(0, blueSpawnPoints.Length);
                Transform selectedSpawnPoint = blueSpawnPoints[randomSpawnIndex];

                blue1Instance = Instantiate(player, selectedSpawnPoint.position, selectedSpawnPoint.rotation);

                // Assign to Blue
                blue1Instance.GetComponent<PlayerCustomization>().isBlueTeam = true;

                // Assign false
                blue1Instance.GetComponent<PlayerCustomization>().isAI = false;
            }
        }
    }

    void SpawnRed1()
    {
        if (red1Instance == null)
        {
            if (red1PlayerType == PlayerType.AI)
            {
                int randomSpawnIndex = UnityEngine.Random.Range(0, redSpawnPoints.Length);
                Transform selectedSpawnPoint = redSpawnPoints[randomSpawnIndex];

                red1Instance = Instantiate(RedAI, selectedSpawnPoint.position, selectedSpawnPoint.rotation);

                // Assign to Red
                red1Instance.GetComponent<PlayerCustomization>().isBlueTeam = false;

                // Assign AI
                red1Instance.GetComponent<PlayerCustomization>().isAI = true;
            }
            else
            {
                int randomSpawnIndex = UnityEngine.Random.Range(0, redSpawnPoints.Length);
                Transform selectedSpawnPoint = redSpawnPoints[randomSpawnIndex];

                red1Instance = Instantiate(player, selectedSpawnPoint.position, selectedSpawnPoint.rotation);

                // Assign to Red
                red1Instance.GetComponent<PlayerCustomization>().isBlueTeam = false;

                // Assign Player
                red1Instance.GetComponent <PlayerCustomization>().isAI = false;
            }
        }
    }

    void KaboomHappened()
    {
        StartCoroutine(ReviveDelay());
    }

    IEnumerator ReviveDelay()
    {
        yield return new WaitForSeconds(2f);

        if (gameState == GameState.Playing)
        {
            SpawnBlue1();

            SpawnRed1();
        }
    }
}
