using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneSetting : MonoBehaviour
{
    [SerializeField] CurrentSceneSO currentSceneSO;
    [SerializeField] string nextSceneName;
    [SerializeField] string nextSceneIntroText;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneSO.nextSceneName = nextSceneName;
        currentSceneSO.nextSceneIntroText = nextSceneIntroText;
    }
}
