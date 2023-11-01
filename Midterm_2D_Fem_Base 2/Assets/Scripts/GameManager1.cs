using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    [SerializeField] private CurrentSceneSO currentSceneSO;
    [SerializeField] private List<string> gameIntroTexts = new List<string>();
    private AudioSource buttonSound;

    // Start is called before the first frame update
    void Start()
    {
        buttonSound = GameObject.Find("Button Sound")?.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Call this function to load the "Cuticles" scene
    public void LoadCuticlesScene()
    {
        buttonSound?.Play();
        currentSceneSO.SetNextSceneName("HandScene");
        currentSceneSO.SetNextSceneText(gameIntroTexts[0]);
        SceneManager.LoadScene("Transition");
    }

    // Call this function to load the "Bird" scene
    public void LoadBirdScene()
    {
        buttonSound?.Play();
        currentSceneSO.SetNextSceneName("BirdScene");
        currentSceneSO.SetNextSceneText(gameIntroTexts[1]);
        SceneManager.LoadScene("Transition");
    }

    // Call this function to load the "Drinks" scene
    public void LoadDrinkScene()
    {
        buttonSound?.Play();
        currentSceneSO.SetNextSceneName("DrinkScene");
        currentSceneSO.SetNextSceneText(gameIntroTexts[2]);
        SceneManager.LoadScene("Transition");
    }

    // Call this function to load the "Glass Ceiling" scene
    public void LoadBonusScene()
    {
        buttonSound?.Play();
        currentSceneSO.SetNextSceneName("BonusScene");
        currentSceneSO.SetNextSceneText(gameIntroTexts[3]);
        SceneManager.LoadScene("Transition");
    }

    // Call this function to load the "Transition" scene
    public void LoadTransitionScene()
    {
        buttonSound?.Play();
        if (currentSceneSO.nextSceneName.Equals("Main Menu")) SceneManager.LoadScene("Main Menu");
        else SceneManager.LoadScene("Transition");
    }

    // Call this function to load the "Transition" scene with the Bonus round
    public void LoadTransitionScene2()
    {
        SceneManager.LoadScene("Bonus Transition");
    }

    // Call this function to quit the game
    public void QuitGame()
    {
        #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    // Call this function to load the "Transition" scene
    public void LoadRestart()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void TryAgain()
    {
        buttonSound?.Play();
        SceneManager.LoadScene(currentSceneSO.currentSceneName);
    }
}
