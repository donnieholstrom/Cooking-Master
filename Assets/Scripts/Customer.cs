using UnityEngine;
using System.Linq;

public class Customer : MonoBehaviour
{
    private int numberOfIngredients;
    private bool angry;
    private float totalTime;
    private float timeRemaining;

    public SpriteRenderer face;

    public Sprite happySprite;
    public Sprite madSprite;

    public Transform bar;

    public Sprite leaves;
    public Sprite slice;
    public Sprite bowl;

    public Color veggiesColor;
    public Color greensColor;
    public Color citrusColor;
    public Color melonsColor;
    public Color pastaColor;
    public Color riceColor;

    public SpriteRenderer ingredientImage1;
    public SpriteRenderer ingredientImage2;
    public SpriteRenderer ingredientImage3;

    public SpriteRenderer ingredientMid1;
    public SpriteRenderer ingredientMid2;

    private GameManager manager;
    private CollectableSpawner collectableSpawner;

    private enum AngryAt
    {
        Nobody,
        PlayerOne,
        PlayerTwo,
        BothPlayers
    }

    private AngryAt angryAt = AngryAt.Nobody;

    public enum Ingredient
    {
        None,
        Veggies,
        Greens,
        Citrus,
        Melons,
        Pasta,
        Rice
    }

    private Ingredient ingredient1 = Ingredient.None;
    private Ingredient ingredient2 = Ingredient.None;
    private Ingredient ingredient3 = Ingredient.None;

    private Ingredient[] request = new Ingredient[3];

    // grabs the game manager
    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Managers").GetComponent<GameManager>();
        collectableSpawner = GameObject.FindGameObjectWithTag("Managers").GetComponent<CollectableSpawner>();
    }

    // creates the customer's ingredient set and sets the time accordingly
    private void Start()
    {
        numberOfIngredients = UnityEngine.Random.Range(1, 4);

        totalTime = 15f * numberOfIngredients;
        timeRemaining = totalTime;

        switch (numberOfIngredients)
        {
            case 1:

                ingredient1 = (Ingredient)UnityEngine.Random.Range(1, 7);

                ingredientImage1.sprite = GetIngredientSprite(Ingredient.None);
                ingredientImage1.color = GetIngredientColor(Ingredient.None);

                ingredientImage2.sprite = GetIngredientSprite(ingredient1);
                ingredientImage2.color = GetIngredientColor(ingredient1);

                ingredientImage3.sprite = GetIngredientSprite(Ingredient.None);
                ingredientImage3.color = GetIngredientColor(Ingredient.None);

                ingredientMid1.sprite = GetIngredientSprite(Ingredient.None);
                ingredientMid1.color = GetIngredientColor(Ingredient.None);

                ingredientMid2.sprite = GetIngredientSprite(Ingredient.None);
                ingredientMid2.color = GetIngredientColor(Ingredient.None);

                break;

            case 2:

                ingredient1 = (Ingredient)UnityEngine.Random.Range(1, 7);
                ingredient2 = (Ingredient)UnityEngine.Random.Range(1, 7);

                ingredientImage1.sprite = GetIngredientSprite(Ingredient.None);
                ingredientImage1.color = GetIngredientColor(Ingredient.None);

                ingredientImage2.sprite = GetIngredientSprite(Ingredient.None);
                ingredientImage2.color = GetIngredientColor(Ingredient.None);

                ingredientImage3.sprite = GetIngredientSprite(Ingredient.None);
                ingredientImage3.color = GetIngredientColor(Ingredient.None);

                ingredientMid1.sprite = GetIngredientSprite(ingredient1);
                ingredientMid1.color = GetIngredientColor(ingredient1);

                ingredientMid2.sprite = GetIngredientSprite(ingredient2);
                ingredientMid2.color = GetIngredientColor(ingredient2);

                break;

            case 3:

                ingredient1 = (Ingredient)UnityEngine.Random.Range(1, 7);
                ingredient2 = (Ingredient)UnityEngine.Random.Range(1, 7);
                ingredient3 = (Ingredient)UnityEngine.Random.Range(1, 7);

                ingredientImage1.sprite = GetIngredientSprite(ingredient1);
                ingredientImage1.color = GetIngredientColor(ingredient1);

                ingredientImage2.sprite = GetIngredientSprite(ingredient2);
                ingredientImage2.color = GetIngredientColor(ingredient2);

                ingredientImage3.sprite = GetIngredientSprite(ingredient3);
                ingredientImage3.color = GetIngredientColor(ingredient3);

                ingredientMid1.sprite = GetIngredientSprite(Ingredient.None);
                ingredientMid1.color = GetIngredientColor(Ingredient.None);

                ingredientMid2.sprite = GetIngredientSprite(Ingredient.None);
                ingredientMid2.color = GetIngredientColor(Ingredient.None);

                break;
        }

        request[0] = ingredient1;
        request[1] = ingredient2;
        request[2] = ingredient3;
    }

    // handles visual updates on the customer object
    private void Update()
    {
        if (timeRemaining <= 0)
        {
            switch (angryAt)
            {
                case AngryAt.Nobody:

                    manager.AddScore(PlayerMovement.PlayerNumber.PlayerOne, -100);
                    manager.AddScore(PlayerMovement.PlayerNumber.PlayerTwo, -100);

                    break;

                case AngryAt.PlayerOne:

                    manager.AddScore(PlayerMovement.PlayerNumber.PlayerOne, -200);

                    break;

                case AngryAt.PlayerTwo:

                    manager.AddScore(PlayerMovement.PlayerNumber.PlayerOne, -200);

                    break;

                case AngryAt.BothPlayers:

                    manager.AddScore(PlayerMovement.PlayerNumber.PlayerOne, -200);
                    manager.AddScore(PlayerMovement.PlayerNumber.PlayerTwo, -200);

                    break;
            }

            Destroy(gameObject);
        }

        else
        {
            if (!angry)
            {
                timeRemaining -= Time.deltaTime;
            }

            else
            {
                timeRemaining -= Time.deltaTime * 1.2f;
            }
        }

        bar.localScale = new Vector3(timeRemaining / totalTime, 0.1232f, 1);
    }

    // tries the meal it is given, and decides how much it likes it
    public void EatMeal(PlayerMovement.PlayerNumber playerNumber, Ingredient mealIngredient1, Ingredient mealIngredient2, Ingredient mealIngredient3)
    {
        Ingredient[] delivery = new Ingredient[3];

        delivery[0] = mealIngredient1;
        delivery[1] = mealIngredient2;
        delivery[2] = mealIngredient3;

        var result = request.Except(delivery);

        if (result.Count() == 0)
        {
            manager.AddScore(playerNumber, 200 * numberOfIngredients);

            if (timeRemaining / totalTime >= 0.5f)
            {
                collectableSpawner.Spawn(playerNumber);
            }

            Destroy(gameObject);
        }

        else
        {
            Anger(playerNumber);
        }
    }

    // literal anger management
    private void Anger(PlayerMovement.PlayerNumber playerNumber)
    {
        if (angry)
        {
            switch (angryAt)
            {
                case AngryAt.PlayerOne:
                    angryAt = AngryAt.BothPlayers;
                    break;

                case AngryAt.PlayerTwo:
                    angryAt = AngryAt.BothPlayers;
                    break;

                case AngryAt.BothPlayers:
                    break;
            }
        }

        else
        {
            angry = true;
            face.sprite = madSprite;

            switch (playerNumber)
            {
                case PlayerMovement.PlayerNumber.PlayerOne:
                    angryAt = AngryAt.PlayerOne;
                    break;

                case PlayerMovement.PlayerNumber.PlayerTwo:
                    angryAt = AngryAt.PlayerTwo;
                    break;
            }
        }
    }

    #region Ingredient Image references

    // returns the sprite that corresponds to the passed ingredient
    public Sprite GetIngredientSprite(Ingredient ingredient)
    {
        switch (ingredient)
        {
            case Ingredient.None:
                return leaves;

            case Ingredient.Veggies:
                return leaves;

            case Ingredient.Greens:
                return leaves;

            case Ingredient.Citrus:
                return slice;

            case Ingredient.Melons:
                return slice;

            case Ingredient.Pasta:
                return bowl;

            case Ingredient.Rice:
                return bowl;
        }

        return leaves;
    }

    // returns the color that corresponds to the passed ingredient
    public Color GetIngredientColor(Ingredient ingredient)
    {
        switch (ingredient)
        {
            case Ingredient.None:
                return Color.clear;

            case Ingredient.Veggies:
                return veggiesColor;

            case Ingredient.Greens:
                return greensColor;

            case Ingredient.Citrus:
                return citrusColor;

            case Ingredient.Melons:
                return melonsColor;

            case Ingredient.Pasta:
                return pastaColor;

            case Ingredient.Rice:
                return riceColor;
        }

        return Color.clear;
    }

    #endregion

}