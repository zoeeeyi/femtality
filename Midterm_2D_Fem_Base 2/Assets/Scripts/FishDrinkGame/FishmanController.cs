using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishmanController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    private float leftScreenEdge; // Left screen edge
    private float rightScreenEdge; // Right screen edge
    private int direction = 1; // 1 for right, -1 for left

    // Start is called before the first frame update
    void Start()
    {
        // Get the boundaries of the screen
        float screenHalfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        leftScreenEdge = -screenHalfWidth;
        rightScreenEdge = screenHalfWidth;
    }

    // Update is called once per frame
    void Update()
    {
        // Move in the current direction
        transform.Translate(Vector3.right * direction * moveSpeed * Time.deltaTime);

        // Check if the GameObject has reached the left or right screen edge
        if (transform.position.x >= rightScreenEdge)
        {
            direction = -1; // Change direction to left
        }
        else if (transform.position.x <= leftScreenEdge)
        {
            direction = 1; // Change direction to right
        }
    }
}

