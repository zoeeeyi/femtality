using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechController : MonoBehaviour
{
    [SerializeField] KeyCode controlKey;
    [SerializeField] NextSceneSetting nextSceneSetting;
    [SerializeField] AudioSource blowSound;
    [SerializeField] AudioSource explodeSound;

    private void Start()
    {
        explodeSound = GameObject.Find("Balloon Explode Audio").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(controlKey))
        {
            blowSound.Stop();
            blowSound.Play();
            transform.localScale *= 1.1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            explodeSound.Play();
            nextSceneSetting.LoseGameInstantly();
        }
    }
}
