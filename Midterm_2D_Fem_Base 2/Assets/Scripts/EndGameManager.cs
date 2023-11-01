using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] CurrentSceneSO currentSceneSO;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject loseUI;

    void Start()
    {
        winUI.SetActive(false);
        loseUI.SetActive(false);

        if (currentSceneSO.currentSceneWinLose) winUI.SetActive(true);
        else loseUI.SetActive(true);
    }
}
