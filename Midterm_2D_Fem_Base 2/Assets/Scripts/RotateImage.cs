using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateImage : MonoBehaviour
{
    public float rotationSpeed = 50f; // Adjust this to change the rotation speed

    // Update is called once per frame
    void Update()
    {
        // Rotate the GameObject over time
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
