using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using TMPro;

public class TransitionController : MonoBehaviour
{
    private Image image;
    private Color initialColor;
    private Color targetColor;
    private float currentLerpTime;
    private float lerpDuration = 1f;

    [SerializeField] private TextMeshProUGUI introText;
    [SerializeField] private CurrentSceneSO currentSceneSO;

    [Header("Background Settings")]
    [SerializeField] private Image backGroundImage;
    [SerializeField] private Sprite drinkSceneImage;
    [SerializeField] private Sprite birdSceneImage;
    [SerializeField] private Sprite handSceneImage;
    [SerializeField] private Sprite bonusSceneImage;

    void Start()
    {
        image = GetComponent<Image>();
        if (image != null)
        {
            initialColor = image.color;
            targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 1f); // 100% opacity
        }

        LoadbgImage();
        LoadNextSceneIntro();

        //if (currentSceneSO.currentSceneName != null) Invoke("LoadNextScene", 3f);

/*
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Transition")
        {
            Invoke("NextScene", 3f);
        }
        else if(currentScene.name == "Transition2")
        {
            Invoke("NextScene2", 3f);
        }
        else
        {
            Invoke("EndScene", 3f);
        }
*/    }

    void Update()
    {
/*        if (currentLerpTime < lerpDuration)
        {
            currentLerpTime += Time.deltaTime;
            float t = currentLerpTime / lerpDuration;
            image.color = Color.Lerp(initialColor, targetColor, t);
        }
*/    }

    void LoadbgImage()
    {
        if (currentSceneSO.nextSceneName != null)
        {
            switch (currentSceneSO.nextSceneName)
            {
                case "DrinkScene":
                    backGroundImage.sprite = drinkSceneImage;
                    break;

                case "HandScene":
                    backGroundImage.sprite = handSceneImage;
                    break;

                case "BridScene":
                    backGroundImage.sprite = birdSceneImage;
                    break;

                case "BonusScene":
                    backGroundImage.sprite = bonusSceneImage;
                    break;

                default:
                    break;
            }
        }
    }

    void LoadNextSceneIntro()
    {
        introText.text = currentSceneSO.nextSceneIntroText;
    }

    public void LoadNextScene()
    {
        string nextSceneName = currentSceneSO.nextSceneName;
        SceneManager.LoadScene(nextSceneName);
    }

/*    void NextScene()
    {
         SceneManager.LoadScene("HandScene");
    }
    void NextScene2()
    {
        SceneManager.LoadScene("BirdScene");
    }
    void EndScene()
    {
        SceneManager.LoadScene("EndGame");
    }
*/
}
