using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed = 3500;

    private Vector2 movement;

    public enum PlayerNumber
    {
        PlayerOne,
        PlayerTwo
    }

    public PlayerNumber playerNumber = PlayerNumber.PlayerOne;

    private string horizontalInput;
    private string verticalInput;

    // get access to Rigidbody2D component
    // sets correct input axes based on player number
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        switch (playerNumber)
        {
            case PlayerNumber.PlayerOne:
                horizontalInput = "Horizontal1";
                verticalInput = "Vertical1";
                break;

            case PlayerNumber.PlayerTwo:
                horizontalInput = "Horizontal2";
                verticalInput = "Vertical2";
                break;
        }
    }

    // get input from the player each frame
    private void Update()
    {
        movement.x = Input.GetAxisRaw(horizontalInput);
        movement.y = Input.GetAxisRaw(verticalInput);
    }

    // move the player each frame (using FixedUpdate() for physics interactions)
    private void FixedUpdate()
    {
        rb.AddForce(movement * moveSpeed * Time.fixedDeltaTime);
    }
}