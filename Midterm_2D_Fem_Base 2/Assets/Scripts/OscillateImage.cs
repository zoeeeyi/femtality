using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillateImage : MonoBehaviour
{
    public float speed = 2f; // Adjust this to change the speed of movement
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // Store the initial position of the GameObject
    }

    void Update()
    {
        // Calculate the vertical movement using the sine function
        float verticalMovement = Mathf.Sin(Time.time * speed) * 1f;

        // Update the GameObject's position based on the calculated vertical movement
        transform.position = new Vector3(startPos.x, startPos.y + verticalMovement, startPos.z);
    }
}
