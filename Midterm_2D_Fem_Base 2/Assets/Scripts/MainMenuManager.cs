using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private CurrentSceneSO currentSceneSO;
    [SerializeField] private TextMeshProUGUI completeText;

    void Start()
    {
        if (currentSceneSO.allGameFinished) completeText.gameObject.SetActive(true);
    }
}
