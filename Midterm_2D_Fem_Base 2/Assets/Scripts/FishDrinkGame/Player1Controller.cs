using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    private float moveSpeed = 10f; // Speed of movement

    private float verticalMoveSpeed = 10f; // Speed of vertical movement
    private float upperYPosition = 7.32f; // Upper Y position
    private float lowerYPosition = -3.18f; // Lower Y position

    private bool isMovingUp = false;
    private bool canFish = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canFish)
        {
            // Move left with A key
            if (Input.GetKey("a"))
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }

            // Move right with D key
            if (Input.GetKey("d"))
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }

            // Start moving up if the lower position is reached and space key is pressed
            if (transform.position.y >= lowerYPosition && Input.GetKeyDown(KeyCode.LeftShift))
            {
                isMovingUp = true;
            }

            // Move up to lower position if moving up is true
            if (isMovingUp && transform.position.y > lowerYPosition)
            {
                transform.Translate(Vector3.down * verticalMoveSpeed * Time.deltaTime);
            }
            else if (transform.position.y <= lowerYPosition)
            {
                // Stop moving up if the lower position is reached
                isMovingUp = false;
            }
        }

        // Move down to upper position if not moving down
        if (!isMovingUp && transform.position.y <= upperYPosition)
        {
            transform.Translate(Vector3.up * verticalMoveSpeed * Time.deltaTime);
        }
        if(transform.position.x <= -12.32)
        {
            transform.position = new Vector3(-12.32f, transform.position.y, transform.position.z);
        }
        else if(transform.position.x >= 12.06)
        {
            transform.position = new Vector3(12.06f, transform.position.y, transform.position.z);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (canFish)
        {
            if (col.gameObject.CompareTag("Drink"))
            {
                Debug.Log("Collision detected with a GameObject tagged as 'Drink'.");

                col.gameObject.SetActive(false);
                ToggleCanFish();

                //TODO: Spawn drink on hook.

                Invoke("ToggleCanFish", 2f);
            }
            else if (col.gameObject.CompareTag("Poison"))
            {
                Debug.Log("Collision detected with a GameObject tagged as 'Poison'.");
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    void ToggleCanFish()
    {
        canFish = !canFish;
    }
}
