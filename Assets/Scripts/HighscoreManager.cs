using UnityEngine;
using System.Linq;

public class HighscoreManager : MonoBehaviour
{
    public int[] highscores = new int[10];

    // makes sure this guy sticks around
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        for (int i = 0; i < highscores.Count(); i++)
        {
            highscores[i] = 0;
        }

        Debug.Log(highscores[1].ToString() + highscores[9].ToString());
    }
}