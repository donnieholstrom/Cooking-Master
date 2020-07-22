using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndMenu : MonoBehaviour
{
    private HighscoreManager highscoreManager;

    public TextMeshProUGUI highscoreLabel1;
    public TextMeshProUGUI highscoreLabel2;
    public TextMeshProUGUI highscoreLabel3;
    public TextMeshProUGUI highscoreLabel4;
    public TextMeshProUGUI highscoreLabel5;
    public TextMeshProUGUI highscoreLabel6;
    public TextMeshProUGUI highscoreLabel7;
    public TextMeshProUGUI highscoreLabel8;
    public TextMeshProUGUI highscoreLabel9;
    public TextMeshProUGUI highscoreLabel10;

    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreText2;

    public TextMeshProUGUI winnerText;


    // gets access to the HighscoreManager
    private void Awake()
    {
        highscoreManager = GameObject.FindGameObjectWithTag("Permanent").GetComponent<HighscoreManager>();
    }

    // updates the highscore ui
    private void Start()
    {
        highscoreLabel1.text = highscoreManager.highscores[0].ToString();
        highscoreLabel2.text = highscoreManager.highscores[1].ToString();
        highscoreLabel3.text = highscoreManager.highscores[2].ToString();
        highscoreLabel4.text = highscoreManager.highscores[3].ToString();
        highscoreLabel5.text = highscoreManager.highscores[4].ToString();
        highscoreLabel6.text = highscoreManager.highscores[5].ToString();
        highscoreLabel7.text = highscoreManager.highscores[6].ToString();
        highscoreLabel8.text = highscoreManager.highscores[7].ToString();
        highscoreLabel9.text = highscoreManager.highscores[8].ToString();
        highscoreLabel10.text = highscoreManager.highscores[9].ToString();

        scoreText1.text = highscoreManager.score1.ToString();
        scoreText2.text = highscoreManager.score2.ToString();

        switch (highscoreManager.winner)
        {
            case HighscoreManager.Winner.PlayerOne:
                winnerText.text = "PLAYER ONE";
                break;

            case HighscoreManager.Winner.PlayerTwo:
                winnerText.text = "PLAYER TWO";
                break;

            case HighscoreManager.Winner.Tie:
                winnerText.text = "THE DEVELOPER";
                break;
        }
    }

    // loads the game scene
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}