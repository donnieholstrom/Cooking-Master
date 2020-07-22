using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public PlayerMovement.PlayerNumber playerNumber;

    private string interactInput;

    private bool hovering;

    public enum Interactable
    {
        Nothing,
        Veggies,
        Greens,
        Citrus,
        Melons,
        Pasta,
        Rice,
        CuttingBoard1,
        CuttingBoard2,
        PickupZone1,
        PickupZone2,
        DeliveryZone1,
        DeliveryZone2,
        DeliveryZone3,
        DeliveryZone4,
        Trashcan
    }

    private Interactable hoveringOn = Interactable.Nothing;

    public Customer.Ingredient heldIngredient1 = Customer.Ingredient.None;
    public Customer.Ingredient heldIngredient2 = Customer.Ingredient.None;

    public SpriteRenderer holding1;
    public SpriteRenderer holding2;

    public Sprite leaves;
    public Sprite slice;
    public Sprite bowl;

    public Color veggiesColor;
    public Color greensColor;
    public Color citrusColor;
    public Color melonsColor;
    public Color pastaColor;
    public Color riceColor;

    public CuttingBoard cuttingBoard;

    public bool holdingMeal = false;

    public SpriteRenderer mealSprite1;
    public SpriteRenderer mealSprite2;
    public SpriteRenderer mealSprite3;
    public SpriteRenderer mealPlate;

    private Customer.Ingredient mealIngredient1;
    private Customer.Ingredient mealIngredient2;
    private Customer.Ingredient mealIngredient3;

    private CustomerManager customerManager;
    private GameManager gameManager;

    // grabs the customer manager and the game manager
    private void Awake()
    {
        customerManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<CustomerManager>();
        gameManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<GameManager>();
    }

    // sets the proper input based on player number
    private void Start()
    {
        switch (playerNumber)
        {
            case (PlayerMovement.PlayerNumber.PlayerOne):
                interactInput = "Interact1";
                break;

            case (PlayerMovement.PlayerNumber.PlayerTwo):
                interactInput = "Interact2";
                break;
        }
    }
    
    // figures out where the player is standing so interacting works with the proper object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hovering)
        {
            return;
        }

        switch (collision.tag)
        {
            case "Veggies":
                hoveringOn = Interactable.Veggies;
                break;

            case "Greens":
                hoveringOn = Interactable.Greens;
                break;

            case "Citrus":
                hoveringOn = Interactable.Citrus;
                break;

            case "Melons":
                hoveringOn = Interactable.Melons;
                break;

            case "Pasta":
                hoveringOn = Interactable.Pasta;
                break;

            case "Rice":
                hoveringOn = Interactable.Rice;
                break;

            case "CuttingBoard1":
                hoveringOn = Interactable.CuttingBoard1;
                break;

            case "CuttingBoard2":
                hoveringOn = Interactable.CuttingBoard2;
                break;

            case "PickupZone1":
                hoveringOn = Interactable.PickupZone1;
                break;

            case "PickupZone2":
                hoveringOn = Interactable.PickupZone2;
                break;

            case "DeliveryZone1":
                hoveringOn = Interactable.DeliveryZone1;
                break;

            case "DeliveryZone2":
                hoveringOn = Interactable.DeliveryZone2;
                break;

            case "DeliveryZone3":
                hoveringOn = Interactable.DeliveryZone3;
                break;

            case "DeliveryZone4":
                hoveringOn = Interactable.DeliveryZone4;
                break;

            case "Trashcan":
                hoveringOn = Interactable.Trashcan;
                break;
        }

        hovering = true;
    }

    // makes sure it grabs the second interactable if it slides between two
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (hoveringOn == Interactable.Nothing)
        {
            switch (collision.tag)
            {
                case "Veggies":
                    hoveringOn = Interactable.Veggies;
                    break;

                case "Greens":
                    hoveringOn = Interactable.Greens;
                    break;

                case "Citrus":
                    hoveringOn = Interactable.Citrus;
                    break;

                case "Melons":
                    hoveringOn = Interactable.Melons;
                    break;

                case "Pasta":
                    hoveringOn = Interactable.Pasta;
                    break;

                case "Rice":
                    hoveringOn = Interactable.Rice;
                    break;

                case "CuttingBoard1":
                    hoveringOn = Interactable.CuttingBoard1;
                    break;

                case "CuttingBoard2":
                    hoveringOn = Interactable.CuttingBoard2;
                    break;

                case "PickupZone1":
                    hoveringOn = Interactable.PickupZone1;
                    break;

                case "PickupZone2":
                    hoveringOn = Interactable.PickupZone2;
                    break;

                case "DeliveryZone1":
                    hoveringOn = Interactable.DeliveryZone1;
                    break;

                case "DeliveryZone2":
                    hoveringOn = Interactable.DeliveryZone2;
                    break;

                case "DeliveryZone3":
                    hoveringOn = Interactable.DeliveryZone3;
                    break;

                case "DeliveryZone4":
                    hoveringOn = Interactable.DeliveryZone4;
                    break;

                case "Trashcan":
                    hoveringOn = Interactable.Trashcan;
                    break;

                default:
                    break;
            }

            hovering = true;
        }
    }

    // clears hoveringOn when player leaves that specific area
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (hovering = true && hoveringOn.ToString().Contains(collision.tag.ToString()))
        {
            hoveringOn = Interactable.Nothing;
            hovering = false;
        }
    }

    // gets input from player
    private void Update()
    {
        if (Input.GetButtonDown(interactInput) && hovering)
        {
            Interact(hoveringOn);
        }
    }

    // handles all interactions
    private void Interact(Interactable interacting)
    {
        switch (interacting)
        {
            case Interactable.Veggies:
                Pickup(Customer.Ingredient.Veggies);
                break;

            case Interactable.Greens:
                Pickup(Customer.Ingredient.Greens);
                break;

            case Interactable.Citrus:
                Pickup(Customer.Ingredient.Citrus);
                break;

            case Interactable.Melons:
                Pickup(Customer.Ingredient.Melons);
                break;

            case Interactable.Pasta:
                Pickup(Customer.Ingredient.Pasta);
                break;

            case Interactable.Rice:
                Pickup(Customer.Ingredient.Rice);
                break;

            case Interactable.CuttingBoard1:

                if (playerNumber == PlayerMovement.PlayerNumber.PlayerOne)
                {
                    if (!cuttingBoard.boardEmpty && cuttingBoard.numberChopped < 3)
                    {
                        cuttingBoard.Interact(Customer.Ingredient.None);
                    }

                    else if (heldIngredient1 != Customer.Ingredient.None)
                    {
                        cuttingBoard.Interact(heldIngredient1);

                        heldIngredient1 = Customer.Ingredient.None;
                        holding1.color = Color.clear;
                    }

                    else if (heldIngredient2 != Customer.Ingredient.None)
                    {
                        cuttingBoard.Interact(heldIngredient2);

                        heldIngredient2 = Customer.Ingredient.None;
                        holding2.color = Color.clear;
                    }

                    else
                    {
                        cuttingBoard.Interact(Customer.Ingredient.None);
                    }
                }

                break;

            case Interactable.CuttingBoard2:

                if (playerNumber == PlayerMovement.PlayerNumber.PlayerTwo)
                {
                    if (!cuttingBoard.boardEmpty && cuttingBoard.numberChopped < 3)
                    {
                        cuttingBoard.Interact(Customer.Ingredient.None);
                    }

                    else if (heldIngredient1 != Customer.Ingredient.None)
                    {
                        if (cuttingBoard.Interact(heldIngredient1))
                        {
                            heldIngredient1 = Customer.Ingredient.None;
                            holding1.color = Color.clear;
                        }
                    }

                    else if (heldIngredient2 != Customer.Ingredient.None)
                    {
                        if (cuttingBoard.Interact(heldIngredient2))
                        {
                            heldIngredient2 = Customer.Ingredient.None;
                            holding2.color = Color.clear;
                        }
                    }

                    else
                    {
                        cuttingBoard.Interact(Customer.Ingredient.None);
                    }
                }

                break;

            case Interactable.PickupZone1:

                if (playerNumber == PlayerMovement.PlayerNumber.PlayerOne)
                {
                    if (!holdingMeal)
                    {
                        cuttingBoard.TakeMeal();
                    }
                }

                break;

            case Interactable.PickupZone2:

                if (playerNumber == PlayerMovement.PlayerNumber.PlayerTwo)
                {
                    if (!holdingMeal)
                    {
                        cuttingBoard.TakeMeal();
                    }
                }

                break;

            case Interactable.DeliveryZone1:

                customerManager.DeliverMeal(playerNumber, 1, mealIngredient1, mealIngredient2, mealIngredient3);

                holdingMeal = false;

                mealPlate.color = Color.clear;

                mealSprite1.color = Color.clear;
                mealIngredient1 = Customer.Ingredient.None;

                mealSprite2.color = Color.clear;
                mealIngredient2 = Customer.Ingredient.None;

                mealSprite3.color = Color.clear;
                mealIngredient3 = Customer.Ingredient.None;
                
                break;

            case Interactable.DeliveryZone2:

                customerManager.DeliverMeal(playerNumber, 2, mealIngredient1, mealIngredient2, mealIngredient3);

                holdingMeal = false;

                mealPlate.color = Color.clear;

                mealSprite1.color = Color.clear;
                mealIngredient1 = Customer.Ingredient.None;

                mealSprite2.color = Color.clear;
                mealIngredient2 = Customer.Ingredient.None;

                mealSprite3.color = Color.clear;
                mealIngredient3 = Customer.Ingredient.None;

                break;

            case Interactable.DeliveryZone3:

                customerManager.DeliverMeal(playerNumber, 3, mealIngredient1, mealIngredient2, mealIngredient3);

                holdingMeal = false;

                mealPlate.color = Color.clear;

                mealSprite1.color = Color.clear;
                mealIngredient1 = Customer.Ingredient.None;

                mealSprite2.color = Color.clear;
                mealIngredient2 = Customer.Ingredient.None;

                mealSprite3.color = Color.clear;
                mealIngredient3 = Customer.Ingredient.None;

                break;

            case Interactable.DeliveryZone4:

                customerManager.DeliverMeal(playerNumber, 4, mealIngredient1, mealIngredient2, mealIngredient3);

                holdingMeal = false;

                mealPlate.color = Color.clear;

                mealSprite1.color = Color.clear;
                mealIngredient1 = Customer.Ingredient.None;

                mealSprite2.color = Color.clear;
                mealIngredient2 = Customer.Ingredient.None;

                mealSprite3.color = Color.clear;
                mealIngredient3 = Customer.Ingredient.None;

                break;

            case Interactable.Trashcan:
                Trash();
                break;

            case Interactable.Nothing:
                break;
        }
    }

    // handles which slot the ingredients go to
    private void Pickup(Customer.Ingredient ingredient)
    {
        if (heldIngredient1 == Customer.Ingredient.None)
        {
            heldIngredient1 = ingredient;

            holding1.sprite = GetIngredientSprite(ingredient);
            holding1.color = GetIngredientColor(ingredient);

            return;
        }

        else if (heldIngredient2 == Customer.Ingredient.None)
        {
            heldIngredient2 = ingredient;

            holding2.sprite = GetIngredientSprite(ingredient);
            holding2.color = GetIngredientColor(ingredient);

            return;
        }

        else
        {
            return;
        }
    }
    
    // handles interacting with the trashcan
    private void Trash()
    {
        if (holdingMeal)
        {
            gameManager.AddScore(playerNumber, -250);

            holdingMeal = false;

            mealPlate.color = Color.clear;

            mealSprite1.color = Color.clear;
            mealIngredient1 = Customer.Ingredient.None;

            mealSprite2.color = Color.clear;
            mealIngredient2 = Customer.Ingredient.None;

            mealSprite3.color = Color.clear;
            mealIngredient3 = Customer.Ingredient.None;
        }

        if (heldIngredient1 != Customer.Ingredient.None)
        {
            heldIngredient1 = Customer.Ingredient.None;
            holding1.color = Color.clear;

            return;
        }

        else if (heldIngredient2 != Customer.Ingredient.None)
        {
            heldIngredient2 = Customer.Ingredient.None;
            holding2.color = Color.clear;

            return;
        }
    }

    // takes the meal from the cutting board
    public void TakeMeal(Customer.Ingredient boardMealIngredient1, Customer.Ingredient boardMealIngredient2, Customer.Ingredient boardMealIngredient3)
    {
        holdingMeal = true;

        mealPlate.color = Color.black;

        mealSprite1.sprite = GetIngredientSprite(boardMealIngredient1);
        mealSprite1.color = GetIngredientColor(boardMealIngredient1);
        mealIngredient1 = boardMealIngredient1;

        mealSprite2.sprite = GetIngredientSprite(boardMealIngredient2);
        mealSprite2.color = GetIngredientColor(boardMealIngredient2);
        mealIngredient2 = boardMealIngredient2;

        mealSprite3.sprite = GetIngredientSprite(boardMealIngredient3);
        mealSprite3.color = GetIngredientColor(boardMealIngredient3);
        mealIngredient3 = boardMealIngredient3;
    }

    #region Ingredient Image references

    // returns the sprite that corresponds to the passed ingredient
    public Sprite GetIngredientSprite(Customer.Ingredient ingredient)
    {
        switch (ingredient)
        {
            case Customer.Ingredient.None:
                return leaves;

            case Customer.Ingredient.Veggies:
                return leaves;

            case Customer.Ingredient.Greens:
                return leaves;

            case Customer.Ingredient.Citrus:
                return slice;

            case Customer.Ingredient.Melons:
                return slice;

            case Customer.Ingredient.Pasta:
                return bowl;

            case Customer.Ingredient.Rice:
                return bowl;
        }

        return leaves;
    }

    // returns the color that corresponds to the passed ingredient
    public Color GetIngredientColor(Customer.Ingredient ingredient)
    {
        switch (ingredient)
        {
            case Customer.Ingredient.None:
                return Color.clear;

            case Customer.Ingredient.Veggies:
                return veggiesColor;

            case Customer.Ingredient.Greens:
                return greensColor;

            case Customer.Ingredient.Citrus:
                return citrusColor;

            case Customer.Ingredient.Melons:
                return melonsColor;

            case Customer.Ingredient.Pasta:
                return pastaColor;

            case Customer.Ingredient.Rice:
                return riceColor;
        }

        return Color.clear;
    }

    #endregion

}