using UnityEngine;
using System.Collections.Generic;

public class HighscoreManager : MonoBehaviour
{
    public List<int> highscores = new List<int>();

    public enum Winner
    {
        PlayerOne,
        PlayerTwo,
        Tie
    }

    public Winner winner = Winner.Tie;

    public int score1;
    public int score2;

    // makes sure this guy sticks around, creates the highscore list with 0s
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        for (int i = 1; i <= 10; i++)
        {
            highscores.Add(0);
        }
    }
}