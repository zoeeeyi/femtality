using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Call this function to load the "Cuticles" scene
    public void LoadCuticlesScene()
    {
        SceneManager.LoadScene("HandScene");
    }

    // Call this function to load the "Bird" scene
    public void LoadBirdScene()
    {
        SceneManager.LoadScene("BirdScene");
    }

    // Call this function to load the "Drinks" scene
    public void LoadDrinkScene()
    {
        SceneManager.LoadScene("DrinkScene");
    }

    // Call this function to load the "Glass Ceiling" scene
    public void LoadBonusScene()
    {
        SceneManager.LoadScene("BonusScene");
    }

    // Call this function to load the "Transition" scene
    public void LoadTransitionScene()
    {
        SceneManager.LoadScene("Transition");
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
}
