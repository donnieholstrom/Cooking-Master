using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timeText1;
    public TextMeshProUGUI timeText2;

    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreText2;

    // update both players' time ui
    public void UpdateTime(float time1, float time2)
    {
        timeText1.text = ((int)time1).ToString();
        timeText2.text = ((int)time2).ToString();
    }

    // update player 1 score ui
    public void UpdateScore1(int score)
    {
        scoreText1.text = score.ToString();
    }

    // update player 2 score ui
    public void UpdateScore2(int score)
    {
        scoreText2.text = score.ToString();
    }
}
