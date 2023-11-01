using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneSetting : MonoBehaviour
{
    [SerializeField] CurrentSceneSO currentSceneSO;
    [SerializeField] string nextSceneName;
    string nextSceneIntroText;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneSO.SetCurrentSceneWinLose(true);
        currentSceneSO.SetCurrentSceneName(SceneManager.GetActiveScene().name);
        currentSceneSO.nextSceneName = nextSceneName;
        currentSceneSO.nextSceneIntroText = nextSceneIntroText;
    }

    public void LoseGameInstantly()
    {
        currentSceneSO.SetCurrentSceneWinLose(false);
        SceneManager.LoadScene("EndGame");
    }

    public void LoseGameDelayed()
    {
        currentSceneSO.SetCurrentSceneWinLose(false);
    }

    public void WinGameInstantly()
    {
        SceneManager.LoadScene("Endgame");
    }
}
