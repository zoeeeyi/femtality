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

    [Header("Audio Settings")]
    [SerializeField] private AudioSource leftHandAudio;
    [SerializeField] private AudioSource leftHandPainAudio;
    [SerializeField] private AudioSource rightHandAudio;
    [SerializeField] private AudioSource rightHandPainAudio;

    [Header("Finger Sprite Settings")]
    [SerializeField] private GameObject[] leftHandSprites;
    [SerializeField] private GameObject[] rightHandSprites;
    int leftHandIndex = 0;
    int rightHandIndex = 0;

    [Header("Score System")]
    GameObject scoreManagerGO;
    ScoreManager scoreManager;
    int p1Score;
    int p2Score;
    bool p1Active = true;
    bool p2Active = true;
    [SerializeField] private TMP_Text p1ScoreText;
    [SerializeField] private TMP_Text p2ScoreText;
    [SerializeField] private GameObject p1Lost;
    [SerializeField] private GameObject p2Lost;

    [SerializeField] private NextSceneSetting nextSceneSetting;

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

        if (!p1Active)
        {
            foreach (Image image in imageToChangeL1)
            {
                image.color = new Vector4(0, 0, 0, 0);
            }
            foreach (Image image in imageToChangeL2)
            {
                image.color = new Vector4(0, 0, 0, 0);
            }
        }

        if (!p2Active)
        {
            foreach (Image image in imageToChangeR1)
            {
                image.color = new Vector4(0, 0, 0, 0);
            }
            foreach (Image image in imageToChangeR2)
            {
                image.color = new Vector4(0, 0, 0, 0);
            }
        }

        if (patternNumL == 1 && p1Active)
        {
            pattern1L.SetActive(true);
            pattern2L.SetActive(false);
            DetectInputLeft1();
        }
        if (patternNumR == 1 && p2Active)
        {
            pattern1R.SetActive(true);
            pattern2R.SetActive(false);
            DetectInputRight1();
        }

        if (patternNumL == 2 && p1Active)
        {
            pattern2L.SetActive(true);
            DetectInputLeft2();
        }
        if (patternNumR == 2 && p2Active)
        {
            pattern2R.SetActive(true);
            DetectInputRight2();
        }

        if (p1Active)
        {
            p1ScoreText.text = p1Score.ToString();
            scoreManager.p1Score = p1Score;
        }
        if (p2Active)
        {
            p2ScoreText.text = p2Score.ToString();
            scoreManager.p2Score = p2Score;
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
            leftHandAudio.Play();
            //turn current sprite green
            Color green = Color.green;
            green.a = 0.5f;
            imageToChangeL1[currentKeyIndexL].color = green;
                
            currentKeyIndexL++;

            p1Score += 10;

            return;
        }

        else if (Input.anyKey && Input.inputString != sequenceL1[currentKeyIndexL].ToString().ToLower() && Input.inputString != sequenceL1[currentKeyIndexL].ToString().ToUpper() && Input.inputString != "" && !Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.RightArrow))
        {
            leftHandPainAudio.Play();
            //turn current sprite red
            Color red = Color.red;
            red.a = 0.5f;
            imageToChangeL1[currentKeyIndexL].color = red;
                
            currentKeyIndexL++;

            currentSceneSO.SetCurrentSceneWinLose(false);

            if (leftHandIndex < leftHandSprites.Length)
            {
                leftHandSprites[leftHandIndex].SetActive(false);
                leftHandIndex++;
            }
            else
            {
                foreach (Image image in imageToChangeL1)
                {
                    image.color = red;
                }
                p1Score -= 15;
                p1Active = false;
                p1Lost.SetActive(true);
                if (!p2Active) nextSceneSetting.LoseGameInstantly();
            }

            p1Score -= 5;

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
            leftHandAudio.Play();
            //turn current sprite green
            Color green = Color.green;
            green.a = 0.5f;
            imageToChangeL2[currentKeyIndexL].color = green;
            currentKeyIndexL++;
            p1Score += 10;

            return;
        }

        else if (Input.anyKey && Input.inputString != sequenceL2[currentKeyIndexL].ToString().ToLower() && Input.inputString != sequenceL2[currentKeyIndexL].ToString().ToUpper() && Input.inputString != "" && !Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.RightArrow))
        {
            leftHandPainAudio.Play();
            //turn current sprite red
            Color red = Color.red;
            red.a = 0.5f;
            imageToChangeL2[currentKeyIndexL].color = red;

            currentKeyIndexL++;

            currentSceneSO.SetCurrentSceneWinLose(false);

            if (leftHandIndex < leftHandSprites.Length)
            {
                leftHandSprites[leftHandIndex].SetActive(false);
                leftHandIndex++;
            }
            else
            {
                foreach (Image image in imageToChangeL2)
                {
                    image.color = red;
                }
                p1Score -= 15;
                p1Active = false;
                p1Lost.SetActive(true);
                if (!p2Active) nextSceneSetting.LoseGameInstantly();
            }

            p1Score -= 5;

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
            rightHandAudio.Play();
            //turn current sprite green
            Color green = Color.green;
            green.a = 0.5f;
            imageToChangeR1[currentKeyIndexR].color = green;
            currentKeyIndexR++;

            p2Score += 10;

            return;
        }

        else if (Input.anyKey && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            rightHandPainAudio.Play();
            //turn current sprite red
            Color red = Color.red;
            red.a = 0.5f;
            imageToChangeR1[currentKeyIndexR].color = red;

            currentKeyIndexR++;

            currentSceneSO.SetCurrentSceneWinLose(false);

            if (rightHandIndex < rightHandSprites.Length)
            {
                rightHandSprites[rightHandIndex].SetActive(false);
                rightHandIndex++;
            }
            else
            {
                foreach (Image image in imageToChangeR1)
                {
                    image.color = red;
                }
                p2Score -= 15;

                p2Active = false;
                p2Lost.SetActive(true);
                if (!p1Active) nextSceneSetting.LoseGameInstantly();
            }

            p2Score -= 5;

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
            rightHandAudio.Play();
            //turn current sprite green
            Color green = Color.green;
            green.a = 0.5f;
            imageToChangeR2[currentKeyIndexR].color = green;
            currentKeyIndexR++;

            p2Score += 10;

            return;
        }

        else if (Input.anyKey && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            rightHandPainAudio.Play();
            //turn current sprite red
            Color red = Color.red;
            red.a = 0.5f;
            imageToChangeR2[currentKeyIndexR].color = red;

            currentKeyIndexR++;

            currentSceneSO.SetCurrentSceneWinLose(false);

            if (rightHandIndex < rightHandSprites.Length)
            {
                rightHandSprites[rightHandIndex].SetActive(false);
                rightHandIndex++;
            }
            else
            {
                foreach (Image image in imageToChangeR2)
                {
                    image.color = red;
                }
                p2Score -= 15;

                p2Active = false;
                p2Lost.SetActive(true);
                if (!p1Active) nextSceneSetting.LoseGameInstantly();
            }

            p2Score -= 5;

            return;
        }
    }

    void EndGame()
    {
        SceneManager.LoadScene("EndGame");
    }
}
