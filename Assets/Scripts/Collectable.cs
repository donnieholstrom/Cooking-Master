using UnityEngine;
using TMPro;

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

    public PlayerMovement.PlayerNumber ownedBy;

    public TextMeshPro numberDisplay;

    private PlayerMovement player1;
    private PlayerMovement player2;

    private GameManager gameManager;

    private CollectableSpawner spawner;

    // gets access to all the good stuff
    private void Awake()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerMovement>();
        player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerMovement>();

        gameManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<GameManager>();
        spawner = GameObject.FindGameObjectWithTag("Managers").GetComponent<CollectableSpawner>();
    }

    private void Start()
    {
        switch (ownedBy)
        {
            case PlayerMovement.PlayerNumber.PlayerOne:
                numberDisplay.text = "1";
                break;

            case PlayerMovement.PlayerNumber.PlayerTwo:
                numberDisplay.text = "2";
                break;
        }
    }

    // handles all the corresponding logic triggers for each collectable
    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (type)
        {
            case Type.Speed:

                if (collision.CompareTag("Player1") && ownedBy == PlayerMovement.PlayerNumber.PlayerOne && player1.SpeedBoost(duration, power))
                {
                    Die();
                }

                else if (collision.CompareTag("Player2") && ownedBy == PlayerMovement.PlayerNumber.PlayerTwo && player2.SpeedBoost(duration,power))
                {
                    Die();
                }

                break;

            case Type.Points:

                if (collision.CompareTag("Player1") && ownedBy == PlayerMovement.PlayerNumber.PlayerOne)
                {
                    gameManager.AddScore(PlayerMovement.PlayerNumber.PlayerOne, power);
                    Die();
                }

                else if (collision.CompareTag("Player2") && ownedBy == PlayerMovement.PlayerNumber.PlayerTwo)
                {
                    gameManager.AddScore(PlayerMovement.PlayerNumber.PlayerTwo, power);
                    Die();
                }

                break;

            case Type.Time:

                if (collision.CompareTag("Player1") && ownedBy == PlayerMovement.PlayerNumber.PlayerOne)
                {
                    gameManager.AddTime(PlayerMovement.PlayerNumber.PlayerOne, power);
                    Die();
                }

                else if (collision.CompareTag("Player2") && ownedBy == PlayerMovement.PlayerNumber.PlayerTwo)
                {
                    gameManager.AddTime(PlayerMovement.PlayerNumber.PlayerTwo, power);
                    Die();
                }

                break;
        }
    }

    // handles what needs to happen before the collectable is destroyed
    private void Die()
    {
        spawner.numberSpawned -= 1;

        Destroy(gameObject);
    }
}
