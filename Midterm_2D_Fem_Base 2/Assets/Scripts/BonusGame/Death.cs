using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update

    private int deadPlayerCount = 0;
    [SerializeField] NextSceneSetting nextSceneSetting;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        deadPlayerCount++;
        Destroy(collision.gameObject);
        nextSceneSetting.LoseGameDelayed();

        if (deadPlayerCount == 2)
        {
            nextSceneSetting.LoseGameInstantly();
        }
    }
}
