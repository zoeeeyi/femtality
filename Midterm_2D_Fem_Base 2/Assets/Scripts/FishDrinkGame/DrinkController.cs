using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkController : MonoBehaviour
{

    public GameObject[] drinks; // Array of GameObjects
    private GameObject randomDrink; // Randomly chosen GameObject
    private int safeDrinkCount = 0;
    private int pickedDrink = 0;
    [SerializeField] private NextSceneSetting nextSceneSetting;

    // Start is called before the first frame update
    void Start()
    {
        // Pick a random GameObject from the array
        randomDrink = drinks[Random.Range(0, drinks.Length)];

        // Assign the "Poison" tag to the randomly chosen GameObject
        randomDrink.tag = "Poison";

        randomDrink.GetComponent<SpriteRenderer>().color = Color.green;

        Debug.Log("Assigned tag 'Poison' to " + randomDrink.name);
    }

    public void pickupSafeDrink()
    {
        pickedDrink++;
        safeDrinkCount++;
        if (safeDrinkCount == drinks.Length - 1) nextSceneSetting.WinGameInstantly();
        if (pickedDrink == drinks.Length) nextSceneSetting.LoseGameInstantly();
    }

    public void pickupPoison()
    {
        nextSceneSetting.LoseGameInstantly();
        pickedDrink++;
        if (pickedDrink == drinks.Length) nextSceneSetting.LoseGameInstantly();
    }
}
