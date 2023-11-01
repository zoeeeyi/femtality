using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CeilingCollider : MonoBehaviour
{
    [SerializeField] CurrentSceneSO currentSceneSO;
    [SerializeField] private GameObject shatteredCeiling;
    private int finishedPlayerCount = 0;
    private bool gameFinished = false;

    // OnTriggerEnter method to handle collision with the ceiling
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !gameFinished)
        {
            if (!currentSceneSO.currentSceneWinLose) FinishGame();
            else
            {
                finishedPlayerCount++;
                if (finishedPlayerCount == 2)
                {
                    gameFinished = true;
                    // Spawn the new sprite when a collision with the ceiling occurs
                    Vector3 spawnPosition = other.transform.position + Vector3.up * 2f;
                    Instantiate(shatteredCeiling, spawnPosition, Quaternion.identity);

                    Invoke("FinishGame", 1.5f);

                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        }
    }

    void FinishGame()
    {
        SceneManager.LoadScene("EndGame");
    }
}
