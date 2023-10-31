using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image fader;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        //CrossFadeAlpha inputs: how faded between 0 and 1, how fast, time scale ignore true/false
        //true keeps normal time, false keeps time you've set for your game
        fader.CrossFadeAlpha(0, 2, true);
        yield return new WaitForSeconds(2);
        //fader.CrossFadeAlpha(1,2,true);
        
    }

    // This code is being referenced in the other script
    public void PrintHi()
    {
        
        print("hi");

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Restart Scene");
            Destroy(gameObject);
        }
    }

/*
    public void LoadLevel(string sceneName)
    {
        StartCoroutine(FadeOut.(sceneName));
    }
    */

}
