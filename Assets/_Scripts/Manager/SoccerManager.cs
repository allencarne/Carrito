using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

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
    PlayerType blue2PlayerType = PlayerType.None;
    PlayerType blue3PlayerType = PlayerType.None;

    PlayerType red1PlayerType = PlayerType.None;
    PlayerType red2PlayerType = PlayerType.None;
    PlayerType red3PlayerType = PlayerType.None;

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
        Random,
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
            if (System.Enum.IsDefined(typeof(MapType), mapTypeValue))
            {
                MapType mapType;

                // If "Random" is selected, choose a random map type
                if ((MapType)mapTypeValue == MapType.Random)
                {
                    mapType = (MapType)Random.Range(1, 5); // Exclude MapType.Random
                }
                else
                {
                    mapType = (MapType)mapTypeValue;
                }

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

    #region Count Down State

    void CountDownState()
    {
        Time.timeScale = 1;

        // Retrieve player types from PlayerPrefs
        blue1PlayerType = (PlayerType)System.Enum.Parse(typeof(PlayerType), PlayerPrefs.GetString("Blue1Type", PlayerType.None.ToString()));
        red1PlayerType = (PlayerType)System.Enum.Parse(typeof(PlayerType), PlayerPrefs.GetString("Red1Type", PlayerType.None.ToString()));

        blue2PlayerType = (PlayerType)System.Enum.Parse(typeof(PlayerType), PlayerPrefs.GetString("Blue2Type", PlayerType.None.ToString()));
        red2PlayerType = (PlayerType)System.Enum.Parse(typeof(PlayerType), PlayerPrefs.GetString("Red2Type", PlayerType.None.ToString()));

        blue3PlayerType = (PlayerType)System.Enum.Parse(typeof(PlayerType), PlayerPrefs.GetString("Blue3Type", PlayerType.None.ToString()));
        red3PlayerType = (PlayerType)System.Enum.Parse(typeof(PlayerType), PlayerPrefs.GetString("Red3Type", PlayerType.None.ToString()));

        switch (gameMode)
        {
            case GameMode.FreePlay:
                CountDown();
                SpawnBall();

                // Spawn Blue 1 Player
                if (blue1Instance == null)
                {
                    int randomSpawnIndex = Random.Range(0, blueSpawnPoints.Length);
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
                //SpawnBlue1();
                //SpawnRed1();

                break;
            case GameMode.TwoVsTwo:
                CountDown();
                SpawnBall();

                // Get Random Spawn Points
                int randomBlueSpawnIndex1 = Random.Range(0, blueSpawnPoints.Length);
                Transform blueSpawnPoint1 = blueSpawnPoints[randomBlueSpawnIndex1];

                int randomBlueSpawnIndex2;
                Transform blueSpawnPoint2;

                // Make sure the second spawn point is different from the first one
                do
                {
                    randomBlueSpawnIndex2 = Random.Range(0, blueSpawnPoints.Length);
                    blueSpawnPoint2 = blueSpawnPoints[randomBlueSpawnIndex2];
                } while (blueSpawnPoint2 == blueSpawnPoint1);

                // Assign Blue 1 And 2 Different spawn Locations
                SpawnBlue1(blueSpawnPoint1);
                SpawnBlue2(blueSpawnPoint2);

                // Get Random Spawn Points
                int randomRedSpawnIndex1 = Random.Range(0, redSpawnPoints.Length);
                Transform redSpawnPoint1 = redSpawnPoints[randomRedSpawnIndex1];

                int randomRedSpawnIndex2;
                Transform redSpawnPoint2;

                // Make sure the second spawn point is different from the first one
                do
                {
                    randomRedSpawnIndex2 = Random.Range(0, redSpawnPoints.Length);
                    redSpawnPoint2 = redSpawnPoints[randomRedSpawnIndex2];
                } while (redSpawnPoint2 == redSpawnPoint1);


                SpawnRed1(redSpawnPoint1);
                SpawnRed2(redSpawnPoint2);

                break;
            case GameMode.ThreeVsThree:
                CountDown();
                SpawnBall();

                // Get Random Spawn Points for Blue Team
                int randomBlueSpawnIndex1_ = Random.Range(0, blueSpawnPoints.Length);
                Transform blueSpawnPoint1_ = blueSpawnPoints[randomBlueSpawnIndex1_];

                int randomBlueSpawnIndex2_;
                Transform blueSpawnPoint2_;

                // Make sure the second spawn point is different from the first one
                do
                {
                    randomBlueSpawnIndex2_ = Random.Range(0, blueSpawnPoints.Length);
                    blueSpawnPoint2_ = blueSpawnPoints[randomBlueSpawnIndex2_];
                } while (blueSpawnPoint2_ == blueSpawnPoint1_);

                int randomBlueSpawnIndex3_;
                Transform blueSpawnPoint3_;

                // Make sure the third spawn point is different from the first two
                do
                {
                    randomBlueSpawnIndex3_ = Random.Range(0, blueSpawnPoints.Length);
                    blueSpawnPoint3_ = blueSpawnPoints[randomBlueSpawnIndex3_];
                } while (blueSpawnPoint3_ == blueSpawnPoint1_ || blueSpawnPoint3_ == blueSpawnPoint2_);

                // Assign Blue spawn locations
                SpawnBlue1(blueSpawnPoint1_);
                SpawnBlue2(blueSpawnPoint2_);
                SpawnBlue3(blueSpawnPoint3_);

                // Get Random Spawn Points for Red Team
                int randomRedSpawnIndex1_ = Random.Range(0, redSpawnPoints.Length);
                Transform redSpawnPoint1_ = redSpawnPoints[randomRedSpawnIndex1_];

                int randomRedSpawnIndex2_;
                Transform redSpawnPoint2_;

                // Make sure the second spawn point is different from the first one
                do
                {
                    randomRedSpawnIndex2_ = Random.Range(0, redSpawnPoints.Length);
                    redSpawnPoint2_ = redSpawnPoints[randomRedSpawnIndex2_];
                } while (redSpawnPoint2_ == redSpawnPoint1_);

                int randomRedSpawnIndex3_;
                Transform redSpawnPoint3_;

                // Make sure the third spawn point is different from the first two
                do
                {
                    randomRedSpawnIndex3_ = Random.Range(0, redSpawnPoints.Length);
                    redSpawnPoint3_ = redSpawnPoints[randomRedSpawnIndex3_];
                } while (redSpawnPoint3_ == redSpawnPoint1_ || redSpawnPoint3_ == redSpawnPoint2_);

                // Assign Red spawn locations
                SpawnRed1(redSpawnPoint1_);
                SpawnRed2(redSpawnPoint2_);
                SpawnRed3(redSpawnPoint3_);

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

    #endregion

    #region Playing State

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

    #endregion

    #region Paused State

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

    #endregion

    #region Goal Scored State

    void GoalScoredState()
    {
        isMatchPaused = true;

        blueScoreText.text = blueScore.ToString();
        redScoreText.text = redScore.ToString();

        Destroy(ballInstance);
        Destroy(blue1Instance);
        Destroy(red1Instance);
        Destroy(blue2Instance);
        Destroy(red2Instance);
        Destroy(blue3Instance);
        Destroy(red3Instance);

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

    #endregion

    #region OverTime State

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

    #endregion

    #region GameOver State

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

    #endregion

    void SpawnBall()
    {
        if (ballInstance == null)
        {
            ballInstance = Instantiate(ball, ballSpawnPoint);
        }
    }

    void SpawnBlue1(Transform spawnPoint)
    {
        if (blue1Instance == null)
        {
            if (blue1PlayerType == PlayerType.AI)
            {
                blue1Instance = Instantiate(BlueAI, spawnPoint.position, spawnPoint.rotation);

                // Assign to Blue
                blue1Instance.GetComponent<PlayerCustomization>().isBlueTeam = true;

                // Assign AI
                blue1Instance.GetComponent<PlayerCustomization>().isAI = true;
            }
            else
            {
                blue1Instance = Instantiate(player, spawnPoint.position, spawnPoint.rotation);

                // Assign to Blue
                blue1Instance.GetComponent<PlayerCustomization>().isBlueTeam = true;

                // Assign false
                blue1Instance.GetComponent<PlayerCustomization>().isAI = false;
            }
        }
    }

    void SpawnBlue2(Transform spawnPoint)
    {
        if (blue2Instance == null)
        {
            if (blue2PlayerType == PlayerType.AI)
            {
                blue2Instance = Instantiate(BlueAI, spawnPoint.position, spawnPoint.rotation);

                // Assign to Blue
                blue2Instance.GetComponent<PlayerCustomization>().isBlueTeam = true;

                // Assign AI
                blue2Instance.GetComponent<PlayerCustomization>().isAI = true;
            }
            else
            {
                blue2Instance = Instantiate(player, spawnPoint.position, spawnPoint.rotation);

                // Assign to Blue
                blue2Instance.GetComponent<PlayerCustomization>().isBlueTeam = true;

                // Assign false
                blue2Instance.GetComponent<PlayerCustomization>().isAI = false;
            }
        }
    }

    void SpawnBlue3(Transform spawnPoint)
    {
        if (blue3Instance == null)
        {
            if (blue3PlayerType == PlayerType.AI)
            {
                blue3Instance = Instantiate(BlueAI, spawnPoint.position, spawnPoint.rotation);

                // Assign to Blue
                blue3Instance.GetComponent<PlayerCustomization>().isBlueTeam = true;

                // Assign AI
                blue3Instance.GetComponent<PlayerCustomization>().isAI = true;
            }
            else
            {
                blue3Instance = Instantiate(player, spawnPoint.position, spawnPoint.rotation);

                // Assign to Blue
                blue3Instance.GetComponent<PlayerCustomization>().isBlueTeam = true;

                // Assign false
                blue3Instance.GetComponent<PlayerCustomization>().isAI = false;
            }
        }
    }

    void SpawnRed1(Transform spawnPoint)
    {
        if (red1Instance == null)
        {
            if (red1PlayerType == PlayerType.AI)
            {
                red1Instance = Instantiate(RedAI, spawnPoint.position, spawnPoint.rotation);

                // Assign to Red
                red1Instance.GetComponent<PlayerCustomization>().isBlueTeam = false;

                // Assign AI
                red1Instance.GetComponent<PlayerCustomization>().isAI = true;
            }
            else
            {
                red1Instance = Instantiate(player, spawnPoint.position, spawnPoint.rotation);

                // Assign to Red
                red1Instance.GetComponent<PlayerCustomization>().isBlueTeam = false;

                // Assign Player
                red1Instance.GetComponent <PlayerCustomization>().isAI = false;
            }
        }
    }

    void SpawnRed2(Transform spawnPoint)
    {
        if (red2Instance == null)
        {
            if (red2PlayerType == PlayerType.AI)
            {
                red2Instance = Instantiate(RedAI, spawnPoint.position, spawnPoint.rotation);

                // Assign to Red
                red2Instance.GetComponent<PlayerCustomization>().isBlueTeam = false;

                // Assign AI
                red2Instance.GetComponent<PlayerCustomization>().isAI = true;
            }
            else
            {
                red2Instance = Instantiate(player, spawnPoint.position, spawnPoint.rotation);

                // Assign to Red
                red2Instance.GetComponent<PlayerCustomization>().isBlueTeam = false;

                // Assign Player
                red2Instance.GetComponent<PlayerCustomization>().isAI = false;
            }
        }
    }

    void SpawnRed3(Transform spawnPoint)
    {
        if (red3Instance == null)
        {
            if (red3PlayerType == PlayerType.AI)
            {
                red3Instance = Instantiate(RedAI, spawnPoint.position, spawnPoint.rotation);

                // Assign to Red
                red3Instance.GetComponent<PlayerCustomization>().isBlueTeam = false;

                // Assign AI
                red3Instance.GetComponent<PlayerCustomization>().isAI = true;
            }
            else
            {
                red3Instance = Instantiate(player, spawnPoint.position, spawnPoint.rotation);

                // Assign to Red
                red3Instance.GetComponent<PlayerCustomization>().isBlueTeam = false;

                // Assign Player
                red3Instance.GetComponent<PlayerCustomization>().isAI = false;
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
            int randomBlueSpawnIndex = Random.Range(0, blueSpawnPoints.Length);
            Transform selectedBlueSpawnPoint = blueSpawnPoints[randomBlueSpawnIndex];

            int randomRedSpawnIndex = Random.Range(0, redSpawnPoints.Length);
            Transform selectedRedSpawnPoint = redSpawnPoints[randomRedSpawnIndex];

            if (gameMode == GameMode.OneVsOne)
            {
                SpawnBlue1(selectedBlueSpawnPoint);
                SpawnRed1(selectedRedSpawnPoint);
            }

            if (gameMode == GameMode.TwoVsTwo)
            {
                SpawnBlue1(selectedBlueSpawnPoint);
                SpawnRed1(selectedRedSpawnPoint);

                SpawnBlue2(selectedBlueSpawnPoint);
                SpawnRed2(selectedRedSpawnPoint);
            }

            if (gameMode == GameMode.ThreeVsThree)
            {
                SpawnBlue1(selectedBlueSpawnPoint);
                SpawnRed1(selectedRedSpawnPoint);

                SpawnBlue2(selectedBlueSpawnPoint);
                SpawnRed2(selectedRedSpawnPoint);

                SpawnBlue3(selectedBlueSpawnPoint);
                SpawnRed3(selectedRedSpawnPoint);
            }
        }
    }
}
