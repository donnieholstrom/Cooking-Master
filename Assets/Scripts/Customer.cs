using UnityEngine;

public class Customer : MonoBehaviour
{
    private int numberOfIngredients;
    private bool angry;
    private float totalTime;
    private float timeRemaining;

    public SpriteRenderer face;

    public Transform bar;

    public Color veggies;
    public Color greens;
    public Color citrus;
    public Color melons;
    public Color pasta;
    public Color rice;

    public Sprite ingredientImage1;
    public Sprite ingredientImage2;
    public Sprite ingredientImage3;

    public Sprite ingredientMid1;
    public Sprite ingredientMid2;

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

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("Managers").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        numberOfIngredients = Random.Range(1, 4);

        totalTime = 6f * numberOfIngredients;
        timeRemaining = totalTime;

        switch (numberOfIngredients)
        {
            case 1:

                ingredient1 = (Ingredient)Random.Range(1, 7);

                break;

            case 2:

                ingredient1 = (Ingredient)Random.Range(1, 7);
                ingredient2 = (Ingredient)Random.Range(1, 7);

                break;

            case 3:

                ingredient1 = (Ingredient)Random.Range(1, 7);
                ingredient2 = (Ingredient)Random.Range(1, 7);
                ingredient3 = (Ingredient)Random.Range(1, 7);

                break;
        }
    }

    // Update is called once per frame
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
}