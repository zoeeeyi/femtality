using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BirdController : MonoBehaviour
{
    public TMP_Text timerText;
    private float timeRemaining = 20f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTimer", 0f, 1f); // Calls the method UpdateTimer every 1 second
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining <= 0)
        {
            SceneManager.LoadScene("EndGame");
        }
    }

    void UpdateTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining--;
            UpdateUIText();
        }
    }

    void UpdateUIText()
    {
        // Format the time as a two-digit integer
        string minutes = Mathf.Floor(timeRemaining / 60).ToString("00");
        string seconds = (timeRemaining % 60).ToString("00");

        // Update the text UI with the current time
        //timerText.text = minutes + ":" + seconds;
        timerText.text = seconds;
    }
}
