using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    private Customer customer1;
    private Customer customer2;
    private Customer customer3;
    private Customer customer4;

    

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

    private void SpawnCustomer()
    {
        if (customer1 != null)
        {
            customer1 = Instantiate(customer, slot1).GetComponent<Customer>();
        }

        else if (customer2 != null)
        {
            customer2 = Instantiate(customer, slot2).GetComponent<Customer>();

        }

        if (customer3 != null)
        {
            customer3 = Instantiate(customer, slot3).GetComponent<Customer>();

        }

        if (customer4 != null)
        {
            customer4 = Instantiate(customer, slot4).GetComponent<Customer>();

        }
    }

    public void DeliverMeal(Customer.Ingredient ingredient1, Customer.Ingredient ingredient2, Customer.Ingredient ingredient3)
    {

    }
}