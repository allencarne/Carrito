using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton

    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than once instance of GameManager found!");
            return;
        }

        instance = this;
    }

    #endregion

    [Header("Components")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerInstance;

    [SerializeField] GameObject ball;
    [SerializeField] GameObject ballInstance;

    [SerializeField] Transform[] playerSpawnPoints;  // Array of player spawn points
    [SerializeField] Transform ballSpawnPoint;

    public enum GameState
    {
        WarmUp,
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
        Soccer,
    }

    GameState gameState = GameState.WarmUp;
    public GameMode gameMode = GameMode.FreePlay;

    private void Update()
    {
        switch (gameState)
        {
            case GameState.WarmUp:
                WarmUpState();
                break;
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

    void WarmUpState()
    {
        if (ballInstance == null)
        {
            ballInstance = Instantiate(ball, ballSpawnPoint);
        }
        if (playerInstance == null)
        {
            int randomSpawnIndex = Random.Range(0, playerSpawnPoints.Length);
            Transform selectedSpawnPoint = playerSpawnPoints[randomSpawnIndex];

            playerInstance = Instantiate(player, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
        }
    }

    void CountDownState()
    {

    }

    void PlayingState()
    {

    }

    void PausedState()
    {

    }

    void GoalScoredState()
    {

    }

    void OverTimeState()
    {

    }

    void GameOverState()
    {

    }
}
