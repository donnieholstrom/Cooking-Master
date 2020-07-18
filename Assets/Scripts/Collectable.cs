using UnityEngine;

public class Collectable : MonoBehaviour
{
    public enum Type
    {
        Speed,
        Time,
        Points
    }

    public Type type;

    public int power;
    public float duration = 0f;

    private PlayerMovement player1;
    private PlayerMovement player2;

    private GameManager gameManager;

    // gets access to all the good stuff
    private void Awake()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerMovement>();
        player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerMovement>();

        gameManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<GameManager>();
    }

    // handles all the corresponding logic triggers for each collectable
    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (type)
        {
            case Type.Speed:

                if (collision.CompareTag("Player1") && player1.SpeedBoost(duration, power))
                {
                    Destroy(gameObject);
                }

                else if (collision.CompareTag("Player2") && player2.SpeedBoost(duration,power))
                {
                    Destroy(gameObject);
                }

                break;

            case Type.Points:

                if (collision.CompareTag("Player1"))
                {
                    gameManager.AddScore(PlayerMovement.PlayerNumber.PlayerOne, power);
                    Destroy(gameObject);
                }

                else if (collision.CompareTag("Player2"))
                {
                    gameManager.AddScore(PlayerMovement.PlayerNumber.PlayerTwo, power);
                    Destroy(gameObject);
                }

                break;

            case Type.Time:

                if (collision.CompareTag("Player1"))
                {
                    gameManager.AddTime(PlayerMovement.PlayerNumber.PlayerOne, power);
                    Destroy(gameObject);
                }

                else if (collision.CompareTag("Player2"))
                {
                    gameManager.AddTime(PlayerMovement.PlayerNumber.PlayerTwo, power);
                    Destroy(gameObject);
                }

                break;
        }
    }
}
