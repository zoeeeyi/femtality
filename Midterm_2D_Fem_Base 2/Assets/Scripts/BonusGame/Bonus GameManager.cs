using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGameManager : MonoBehaviour
{
    public GameObject[] floor;
    public GameObject[] prefabs;
    public GameObject ceilingPrefab; // Reference to your ceiling prefab
    public GameObject newSpritePrefab; // Reference to the new sprite prefab

    GameObject randomPrefab;
    Vector3 spawnPosition;
    GameObject ceiling; 

    public int platformCount = 50;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = new Vector3();

        for(int i = 0; i < platformCount; i++)
        {
            spawnPosition.y += Random.Range(.5f,2f);
            spawnPosition.x = Random.Range(-5f,5f);

            randomPrefab = prefabs[Random.Range(0, prefabs.Length)];
            Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
        }

        Invoke("DeleteFloor", 2f);

        StartCoroutine(SpawnCeilingDelayed(2f + (platformCount * 0.2f)));
    }

    void Update()
    {
        
    }

    void DeleteFloor()
    {
        foreach (GameObject obj in floor)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }

    IEnumerator SpawnCeilingDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);

        Vector3 ceilingSpawnPosition = new Vector3(0, spawnPosition.y + 1f, 0);

        GameObject ceiling = Instantiate(ceilingPrefab, ceilingSpawnPosition, Quaternion.identity);
        ceiling.AddComponent<CeilingCollider>(); //Empty CeilingCollider script on the ceiling preFab

        // You can also adjust the collider size and position here if needed
        BoxCollider2D collider = ceiling.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(2f, 0.01f);
        collider.offset = new Vector2(0f, 0.05f);
    }

    // OnTriggerEnter method to handle collision with the ceiling
    void OnTriggerEnter(Collider2D other)
    {
        if (other.CompareTag("Ceiling"))
        {
            // Spawn the new sprite when a collision with the ceiling occurs
            Vector3 spawnPosition = other.transform.position + Vector3.up * 2f; 
            Instantiate(newSpritePrefab, spawnPosition, Quaternion.identity);

            // Destroy the ceiling
            Destroy(ceiling);
        }
    }
}


