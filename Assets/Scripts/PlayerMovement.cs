using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float startMoveSpeed = 3500;
    private float moveSpeed = 3500;

    private Vector2 movement;

    public enum PlayerNumber
    {
        PlayerOne,
        PlayerTwo
    }

    public PlayerNumber playerNumber = PlayerNumber.PlayerOne;

    private string horizontalInput;
    private string verticalInput;

    private bool buffed;

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

    // exposes the ienumerator, grabs the buff duration, returns false if buff is already active
    public bool SpeedBoost(float duration, int power)
    {
        if (buffed)
        {
            Debug.Log("Already buffed!");

            return false;
        }

        StartCoroutine(SpeedBoostEffect(duration, power));
        return true;
    }

    // runs the actual effect of the buff (speeds up the player by 'power' for 'duration')
    private IEnumerator SpeedBoostEffect(float duration, int power)
    {
        buffed = true;
        moveSpeed *= power;

        yield return new WaitForSeconds(duration);

        moveSpeed = startMoveSpeed;
        buffed = false;
    }
}