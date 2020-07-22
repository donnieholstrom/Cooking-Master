using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    private Customer customer1 = null;
    private Customer customer2 = null;
    private Customer customer3 = null;
    private Customer customer4 = null;

    private int customersActive;

    public bool spawning;

    public GameObject customer;

    private float spawnTimer;
    public float timeToSpawn;

    public Transform slot1;
    public Transform slot2;
    public Transform slot3;
    public Transform slot4;

    private GameManager gameManager;

    // grabs the GameManager spawns the first customer
    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<GameManager>();

        spawning = true;

        SpawnCustomer();
    }

    // spawn timing logic
    private void Update()
    {
        if (spawning)
        {
            if (spawnTimer >= timeToSpawn)
            {
                SpawnCustomer();

                spawnTimer = 0f;
            }

            spawnTimer += Time.deltaTime;
        }
    }

    // spawns a customer in an empty slot. does nothing if all slots are full
    private void SpawnCustomer()
    {
        if (customer2 == null)
        {
            customer2 = Instantiate(customer, slot2).GetComponent<Customer>();
        }

        else if (customer3 == null)
        {
            customer3 = Instantiate(customer, slot3).GetComponent<Customer>();
        }

        else if (customer1 == null)
        {
            customer1 = Instantiate(customer, slot1).GetComponent<Customer>();
        }

        else if (customer4 == null)
        {
            customer4 = Instantiate(customer, slot4).GetComponent<Customer>();
        }
    }

    // gives the meal to the corresponding customer and passes in the playerNumber of the player that delivered the meal
    public void DeliverMeal(PlayerMovement.PlayerNumber playerNumber, int customerNumber, Customer.Ingredient ingredient1, Customer.Ingredient ingredient2, Customer.Ingredient ingredient3)
    {
        switch (customerNumber)
        {
            case 1:

                if (customer1 != null)
                {
                    customer1.EatMeal(playerNumber, ingredient1, ingredient2, ingredient3);
                }

                break;

            case 2:

                if (customer2 != null)
                {
                    customer2.EatMeal(playerNumber, ingredient1, ingredient2, ingredient3);
                }

                break;

            case 3:

                if (customer3 != null)
                {
                    customer3.EatMeal(playerNumber, ingredient1, ingredient2, ingredient3);
                }

                break;

            case 4:

                if (customer4 != null)
                {
                    customer4.EatMeal(playerNumber, ingredient1, ingredient2, ingredient3);
                }

                break;
        }
    }
}