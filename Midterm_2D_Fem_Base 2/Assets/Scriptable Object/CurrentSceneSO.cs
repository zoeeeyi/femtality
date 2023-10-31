using UnityEngine;

[CreateAssetMenu(fileName = "CurrentSceneSO", menuName = "ScriptableObjects/CurrentSceneSO", order = 1)]
public class CurrentSceneSO : ScriptableObject
{
    public string nextSceneName;

    public void SetNextSceneName(string sceneName)
    {
        nextSceneName = sceneName;
    }
}