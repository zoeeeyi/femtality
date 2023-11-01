using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;

public class CuticleController : MonoBehaviour
{
    private int patternNumL;
    private int patternNumR;

    //first left pattern
    private KeyCode[] sequenceL1 = { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D };
    private KeyCode[] sequenceL2 = { KeyCode.D, KeyCode.A, KeyCode.A, KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.S };

    //first right pattern
    private KeyCode[] sequenceR1 = { KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.DownArrow };
    private KeyCode[] sequenceR2 = { KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.LeftArrow, KeyCode.UpArrow };

    //pattern image arrays
    public Image[] imageToChangeL1;
    public Image[] imageToChangeR1;
    public Image[] imageToChangeL2;
    public Image[] imageToChangeR2;

    public GameObject pattern1L;
    public GameObject pattern1R;
    public GameObject pattern2L;
    public GameObject pattern2R;
    //public GameObject pattern3;

    int currentKeyIndexL;
    int currentKeyIndexR;

    public TMP_Text timerText;
    [SerializeField] private float timeRemaining = 10f;

    [SerializeField] CurrentSceneSO currentSceneSO;

    // Start is called before the first frame update
    void Start()
    {
        patternNumL = 1;
        patternNumR = 1;
        currentKeyIndexL = 0;
        currentKeyIndexR = 0;

        InvokeRepeating("UpdateTimer", 0f, 1f); // Calls the method UpdateTimer every 1 second
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining <= 0 || (patternNumL == 3 && patternNumR == 3))
        {
            SceneManager.LoadScene("EndGame");
        }

        if(patternNumL == 1)
        {
            pattern1L.SetActive(true);
            pattern2L.SetActive(false);
            DetectInputLeft1();
        }
        if(patternNumR == 1)
        {
            pattern1R.SetActive(true);
            pattern2R.SetActive(false);
            DetectInputRight1();
        }

        if(patternNumL == 2)
        {
            pattern2L.SetActive(true);
            DetectInputLeft2();
        }
        if (patternNumR == 2)
        {
            pattern2R.SetActive(true);
            DetectInputRight2();
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

    void DetectInputLeft1()
    {
        // Check if the whole sequence has been pressed
        if (currentKeyIndexL >= sequenceL1.Length)
        {
            Debug.Log("Sequence Left Complete!");

            // Reset the sequence
            patternNumL = 2;
            pattern1L.SetActive(false);
            currentKeyIndexL = 0;
            return;
        }

        //get input player should press
        if (Input.GetKeyDown(sequenceL1[currentKeyIndexL]))
            {
                //turn current sprite green
                Color green = Color.green;
                green.a = 0.5f;
                imageToChangeL1[currentKeyIndexL].color = green;
                    currentKeyIndexL++;

                return;
            }

            else if (Input.anyKey && Input.inputString != sequenceL1[currentKeyIndexL].ToString().ToLower() && Input.inputString != sequenceL1[currentKeyIndexL].ToString().ToUpper() && Input.inputString != "" && !Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.RightArrow))
        {
                //turn current sprite red
                Color red = Color.red;
                red.a = 0.5f;
                imageToChangeL1[currentKeyIndexL].color = red;
                
                currentKeyIndexL++;

            currentSceneSO.SetCurrentSceneWinLose(false);

                return;
            }
    }

    void DetectInputLeft2()
    {
        // Check if the whole sequence has been pressed
        if (currentKeyIndexL >= sequenceL2.Length)
        {
            Debug.Log("Sequence Left Complete!");

            // Reset the sequence
            patternNumL = 3;
            pattern2L.SetActive(false);
            currentKeyIndexL = 0;
            return;
        }

        //get input player should press
        if (Input.GetKeyDown(sequenceL2[currentKeyIndexL]))
        {
            //turn current sprite green
            Color green = Color.green;
            green.a = 0.5f;
            imageToChangeL2[currentKeyIndexL].color = green;
            currentKeyIndexL++;

            return;
        }

        else if (Input.anyKey && Input.inputString != sequenceL2[currentKeyIndexL].ToString().ToLower() && Input.inputString != sequenceL2[currentKeyIndexL].ToString().ToUpper() && Input.inputString != "" && !Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.RightArrow))
        {
            //turn current sprite red
            Color red = Color.red;
            red.a = 0.5f;
            imageToChangeL2[currentKeyIndexL].color = red;

            currentKeyIndexL++;

            currentSceneSO.SetCurrentSceneWinLose(false);

            return;
        }
    }

    void DetectInputRight1()
    {
        // Check if the whole sequence has been pressed
        if (currentKeyIndexR >= sequenceR1.Length)
        {
            Debug.Log("Sequence Right Complete!");

            // Reset the sequence
            patternNumR = 2;
            pattern1R.SetActive(false);
            currentKeyIndexR = 0;
            return;
        }

        //get input player should press
        if (Input.GetKeyDown(sequenceR1[currentKeyIndexR]))
        {
            //turn current sprite green
            Color green = Color.green;
            green.a = 0.5f;
            imageToChangeR1[currentKeyIndexR].color = green;
            currentKeyIndexR++;

            return;
        }

        else if (Input.anyKey && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            //turn current sprite red
            Color red = Color.red;
            red.a = 0.5f;
            imageToChangeR1[currentKeyIndexR].color = red;

            currentKeyIndexR++;

            currentSceneSO.SetCurrentSceneWinLose(false);

            return;
        }
    }

    void DetectInputRight2()
    {
        // Check if the whole sequence has been pressed
        if (currentKeyIndexR >= sequenceR2.Length)
        {
            Debug.Log("Sequence Right Complete!");

            // Reset the sequence
            patternNumR = 3;
            pattern1R.SetActive(false);
            currentKeyIndexR = 0;
            return;
        }

        //get input player should press
        if (Input.GetKeyDown(sequenceR2[currentKeyIndexR]))
        {
            //turn current sprite green
            Color green = Color.green;
            green.a = 0.5f;
            imageToChangeR2[currentKeyIndexR].color = green;
            currentKeyIndexR++;

            return;
        }

        else if (Input.anyKey && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            //turn current sprite red
            Color red = Color.red;
            red.a = 0.5f;
            imageToChangeR2[currentKeyIndexR].color = red;

            currentKeyIndexR++;

            currentSceneSO.SetCurrentSceneWinLose(false);

            return;
        }
    }

    void EndGame()
    {
        SceneManager.LoadScene("EndGame");
    }
}
