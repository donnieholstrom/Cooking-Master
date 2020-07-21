using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float startTime;

    public PlayerMovement player1;
    public PlayerMovement player2;

    private int score1 = 0;
    private int score2 = 0;

    private float time1;
    private float time2;

    private bool playing1;
    private bool playing2;

    private UIManager uiManager;
    private CustomerManager customerManager;

    // gets reference to the good stuff and sets the start times
    private void Awake()
    {
        uiManager = GetComponent<UIManager>();
        customerManager = GetComponent<CustomerManager>();

        time1 = startTime;
        time2 = startTime;
    }

    // sets playing1 and playing2 to true to start the game, updates UI
    private void Start()
    {
        playing1 = true;
        playing2 = true;
    }

    // increment timers separately for the two players
    private void Update()
    {
        if (playing1)
        {
            time1 -= Time.deltaTime;
        }

        if (playing2)
        {
            time2 -= Time.deltaTime;
        }

        if (time1 <= 0)
        {
            playing1 = false;
            player1.frozen = true;
        }

        if (time2 <= 0)
        {
            playing2 = false;
            player2.frozen = true;
        }

        if (!playing1 &&!playing2)
        {
            // end the game
        }

        uiManager.UpdateTime(time1, time2);
    }

    // adds score to corresponding player
    public void AddScore(PlayerMovement.PlayerNumber playerNumber, int score)
    {
        switch (playerNumber)
        {
            case PlayerMovement.PlayerNumber.PlayerOne:

                score1 += score;

                uiManager.UpdateScore1(score1);

                break;

            case PlayerMovement.PlayerNumber.PlayerTwo:

                score2 += score;

                uiManager.UpdateScore2(score2);

                break;
        }
    }

    // adds time to corresponding player
    public void AddTime(PlayerMovement.PlayerNumber playerNumber, float time)
    {
        switch (playerNumber)
        {
            case PlayerMovement.PlayerNumber.PlayerOne:

                time1 += time;

                break;

            case PlayerMovement.PlayerNumber.PlayerTwo:

                time2 += time;

                break;
        }
    }
}