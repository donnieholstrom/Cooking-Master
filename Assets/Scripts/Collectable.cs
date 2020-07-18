using UnityEngine;

public class Collectable : MonoBehaviour
{
    public enum Type
    {
        Speed,
        Health,
        Points
    }

    public Type type;

    public int power;
    public float duration = 0f;

    // handles all the corresponding logic triggers for each collectable
    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (type)
        {
            case Type.Speed:

                if (collision.GetComponent<PlayerMovement>().SpeedBoost(duration, power))
                {
                    Destroy(gameObject);
                }

                break;

            case Type.Health:

                break;

            case Type.Points:

                break;
        }
    }
}
