using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechController : MonoBehaviour
{
    [SerializeField] KeyCode controlKey;
    [SerializeField] NextSceneSetting nextSceneSetting;
    [SerializeField] AudioSource blowSound;
    [SerializeField] AudioSource explodeSound;

    [SerializeField] private float changeRate = 1.1f;
    [SerializeField] private float targetSize = 3;
    [SerializeField] private Slider balloonSizeIndicator;
    [SerializeField] private BirdController birdController;

    private float changedMult = 1;

    private void Start()
    {
        explodeSound = GameObject.Find("Balloon Explode Audio").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(controlKey))
        {
            if (changedMult < targetSize)
            {
                blowSound.Stop();
                blowSound.Play();
                transform.localScale *= changeRate;
                changedMult *= changeRate;
                balloonSizeIndicator.value = (changedMult - 1) / (targetSize - 1);
                if (changedMult >= targetSize)
                {
                    birdController.AddFinishedPlayer();
                }
            }
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
