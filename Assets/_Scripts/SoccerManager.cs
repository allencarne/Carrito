using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.InputSystem;
using System.Linq;

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
    bool isCountdownInProgress = false;
    public bool CanMove = false;

    // Score
    [SerializeField] TextMeshProUGUI blueScoreText;
    int blueScore;
    [SerializeField] TextMeshProUGUI redScoreText;
    int redScore;

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

    GameState gameState = GameState.CountDown;
    public GameMode gameMode = GameMode.FreePlay;

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
        CanMove = true;

        if (!isCountdownInProgress)
        {
            isCountdownInProgress = true;

            matchTimeText.gameObject.SetActive(true);

            StartCoroutine(MatchTimeCoroutine());
        }

        switch (gameMode)
        {
            case GameMode.FreePlay:
                break;
            case GameMode.Training:
                break;
            case GameMode.OneVsOne:
                break;
            case GameMode.TwoVsTwo:
                break;
            case GameMode.ThreeVsThree:
                break;
        }
    }

    IEnumerator MatchTimeCoroutine()
    {
        float timeRemaining = matchDurationInSeconds;

        while (timeRemaining > 0f)
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

        // End of Match
        matchTimeText.gameObject.SetActive(false);
    }

    void PausedState()
    {
        switch (gameMode)
        {
            case GameMode.FreePlay:
                break;
            case GameMode.Training:
                break;
            case GameMode.OneVsOne:
                break;
            case GameMode.TwoVsTwo:
                break;
            case GameMode.ThreeVsThree:
                break;
        }
    }

    void GoalScoredState()
    {
        switch (gameMode)
        {
            case GameMode.FreePlay:
                break;
            case GameMode.Training:
                break;
            case GameMode.OneVsOne:
                break;
            case GameMode.TwoVsTwo:
                break;
            case GameMode.ThreeVsThree:
                break;
        }
    }

    void OverTimeState()
    {
        switch (gameMode)
        {
            case GameMode.FreePlay:
                break;
            case GameMode.Training:
                break;
            case GameMode.OneVsOne:
                break;
            case GameMode.TwoVsTwo:
                break;
            case GameMode.ThreeVsThree:
                break;
        }
    }

    void GameOverState()
    {
        switch (gameMode)
        {
            case GameMode.FreePlay:
                break;
            case GameMode.Training:
                break;
            case GameMode.OneVsOne:
                break;
            case GameMode.TwoVsTwo:
                break;
            case GameMode.ThreeVsThree:
                break;
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
            }
            else
            {
                int randomSpawnIndex = UnityEngine.Random.Range(0, blueSpawnPoints.Length);
                Transform selectedSpawnPoint = blueSpawnPoints[randomSpawnIndex];

                blue1Instance = Instantiate(player, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
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
            }
            else
            {
                int randomSpawnIndex = UnityEngine.Random.Range(0, redSpawnPoints.Length);
                Transform selectedSpawnPoint = redSpawnPoints[randomSpawnIndex];

                red1Instance = Instantiate(player, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
            }
        }
    }
}
