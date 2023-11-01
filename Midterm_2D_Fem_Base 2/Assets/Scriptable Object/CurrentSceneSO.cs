using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrentSceneSO", menuName = "ScriptableObjects/CurrentSceneSO", order = 1)]
public class CurrentSceneSO : ScriptableObject
{
    public string currentSceneName;
    public bool currentSceneWinLose;

    public string nextSceneName;
    public string nextSceneIntroText;

    public int finishedGameCount = 0;
    public bool allGameFinished = false;

    public void SetCurrentSceneName(string sceneName)
    {
        currentSceneName = sceneName;
    }

    public void SetCurrentSceneWinLose(bool winLose)
    {
        currentSceneWinLose = winLose;
    }

    public void SetNextSceneName(string sceneName)
    {
        nextSceneName = sceneName;
    }

    public void SetNextSceneText(string intro)
    {
        nextSceneIntroText = intro;
    }

    public void AddFinishedGameCount()
    {
        finishedGameCount++;
        if (finishedGameCount == 4) allGameFinished = true;
    }
}