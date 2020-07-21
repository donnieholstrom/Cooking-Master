using UnityEngine;

public class Customer : MonoBehaviour
{
    private int numberOfIngredients;
    private bool angry;
    private float totalTime;
    private float timeRemaining;

    public SpriteRenderer face;

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

    // grabs the game manager
    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Managers").GetComponent<GameManager>();
    }

    // creates the customer's ingredient set and sets the time accordingly
    private void Start()
    {
        numberOfIngredients = Random.Range(1, 4);

        totalTime = 10f * numberOfIngredients;
        timeRemaining = totalTime;

        switch (numberOfIngredients)
        {
            case 1:

                ingredient1 = (Ingredient)Random.Range(1, 7);

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

                ingredient1 = (Ingredient)Random.Range(1, 7);
                ingredient2 = (Ingredient)Random.Range(1, 7);

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

                ingredient1 = (Ingredient)Random.Range(1, 7);
                ingredient2 = (Ingredient)Random.Range(1, 7);
                ingredient3 = (Ingredient)Random.Range(1, 7);

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
    }

    // handles visual updates on the customer object
    private void Update()
    {
        if (timeRemaining <= 0)
        {
            // ran out of time
        }

        else
        {
            timeRemaining -= Time.deltaTime;
        }

        bar.localScale = new Vector3(timeRemaining / totalTime, 0.1232f, 1);
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