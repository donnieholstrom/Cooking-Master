using System.Collections;
using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
    public Sprite leaves;
    public Sprite slice;
    public Sprite bowl;

    public Color veggiesColor;
    public Color greensColor;
    public Color citrusColor;
    public Color melonsColor;
    public Color pastaColor;
    public Color riceColor;

    public SpriteRenderer boardSprite;

    public SpriteRenderer ingredientSprite1;
    public SpriteRenderer ingredientSprite2;
    public SpriteRenderer ingredientSprite3;

    public PlayerMovement player;
    public PlayerInteraction playerInteraction;

    public bool boardEmpty = true;

    public int numberChopped = 0;

    private Customer.Ingredient choppedIngredient1;
    private Customer.Ingredient choppedIngredient2;
    private Customer.Ingredient choppedIngredient3;

    private Customer.Ingredient boardIngredient;

    private bool chopping;

    // decides what kind of interaction, returns true if an ingredient was placed on the board
    public bool Interact(Customer.Ingredient ingredient)
    {
        if (boardEmpty)
        {
            Place(ingredient);
            return true;
        }

        else
        {
            StartCoroutine(Chop());
            return false;
        }
    }

    // handles placement onto the cutting board
    public void Place(Customer.Ingredient ingredient)
    {
        boardSprite.sprite = GetIngredientSprite(ingredient);
        boardSprite.color = GetIngredientColor(ingredient);

        boardIngredient = ingredient;

        boardEmpty = false;
    }

    // handles chopping and then moving the ingredient to the meal area
    public IEnumerator Chop()
    {
        if (chopping || numberChopped >= 3)
        {
            yield break;
        }

        player.frozen = true;
        chopping = true;

        yield return new WaitForSeconds(1f);

        switch (numberChopped)
        {
            case 0:
                ingredientSprite1.sprite = GetIngredientSprite(boardIngredient);
                ingredientSprite1.color = GetIngredientColor(boardIngredient);

                choppedIngredient1 = boardIngredient;

                break;

            case 1:
                ingredientSprite2.sprite = GetIngredientSprite(boardIngredient);
                ingredientSprite2.color = GetIngredientColor(boardIngredient);
                
                choppedIngredient2 = boardIngredient;

                break;

            case 2:
                ingredientSprite3.sprite = GetIngredientSprite(boardIngredient);
                ingredientSprite3.color = GetIngredientColor(boardIngredient);

                choppedIngredient3 = boardIngredient;

                break;
        }

        boardSprite.color = Color.clear;
        boardIngredient = Customer.Ingredient.None;

        player.frozen = false;
        chopping = false;

        boardEmpty = true;
        numberChopped++;
    }

    // takes the meal and clears the meal area
    public void TakeMeal()
    {
        if (numberChopped == 0)
        {
            return;
        }

        playerInteraction.TakeMeal(choppedIngredient1, choppedIngredient2, choppedIngredient3);
        numberChopped = 0;

        ingredientSprite1.color = Color.clear;
        ingredientSprite2.color = Color.clear;
        ingredientSprite3.color = Color.clear;

        choppedIngredient1 = Customer.Ingredient.None;
        choppedIngredient2 = Customer.Ingredient.None;
        choppedIngredient3 = Customer.Ingredient.None;
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