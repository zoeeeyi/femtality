using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrentSceneSO", menuName = "ScriptableObjects/CurrentSceneSO", order = 1)]
public class CurrentSceneSO : ScriptableObject
{
    public string nextSceneName;
    public string nextSceneIntroText;

    public void SetNextSceneName(string sceneName)
    {
        nextSceneName = sceneName;
    }

    public void SetNextSceneText(string intro)
    {
        nextSceneIntroText = intro;
    }
}