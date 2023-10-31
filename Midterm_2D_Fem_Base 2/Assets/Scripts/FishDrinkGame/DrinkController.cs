using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkController : MonoBehaviour
{

    public GameObject[] drinks; // Array of GameObjects
    private GameObject randomDrink; // Randomly chosen GameObject

    // Start is called before the first frame update
    void Start()
    {
        // Pick a random GameObject from the array
        randomDrink = drinks[Random.Range(0, drinks.Length)];

        // Assign the "Poison" tag to the randomly chosen GameObject
        randomDrink.tag = "Poison";

        Debug.Log("Assigned tag 'Poison' to " + randomDrink.name);
    }
}
