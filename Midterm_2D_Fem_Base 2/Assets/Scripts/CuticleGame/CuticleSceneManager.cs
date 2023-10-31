using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuticleSceneManager : MonoBehaviour
{
    [SerializeField] CurrentSceneSO currentSceneSO;
    [SerializeField] string nextSceneName;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneSO.nextSceneName = nextSceneName;
    }
}
