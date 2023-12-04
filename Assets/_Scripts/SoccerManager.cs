using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [Header("Components")]
    [SerializeField] GameObject player;
    public GameObject playerInstance;

    [SerializeField] GameObject AI;
    public GameObject AIInstance;

    [SerializeField] GameObject ball;
    public GameObject ballInstance;

    [SerializeField] Transform[] playerSpawnPoints;  // Array of player spawn points
    [SerializeField] Transform ballSpawnPoint;

    [SerializeField] TextMeshProUGUI countDownText;
    bool canCountDown = true;

    public bool CanMove = false;

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
        switch (gameMode)
        {
            case GameMode.FreePlay:
                CountDown();
                break;
            case GameMode.Training:
                CountDown();
                break;
            case GameMode.OneVsOne:
                CountDown();
                SpawnBall();
                SpawnPlayer();
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
        // Display "3" and wait for 1 second.
        countDownText.text = "3";
        yield return new WaitForSeconds(1f);

        // Display "2" and wait for 1 second.
        countDownText.text = "2";
        yield return new WaitForSeconds(1f);

        // Display "1" and wait for 1 second.
        countDownText.text = "1";
        yield return new WaitForSeconds(1f);

        // Clear the text after the countdown is finished.
        countDownText.text = "Go!";
        yield return new WaitForSeconds(1f);

        // Do Stuff
        CanMove = true;

        // Waits a second before turning off text
        countDownText.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
    }

    void PlayingState()
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

    void SpawnPlayer()
    {
        if (playerInstance == null)
        {
            int randomSpawnIndex = Random.Range(0, playerSpawnPoints.Length);
            Transform selectedSpawnPoint = playerSpawnPoints[randomSpawnIndex];

            playerInstance = Instantiate(player, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
        }
    }
}
