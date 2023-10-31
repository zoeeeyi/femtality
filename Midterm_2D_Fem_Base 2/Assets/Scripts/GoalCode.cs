using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GoalCode : MonoBehaviour
{

    public string levelToLoad = "HandScene";
    //For OnTrigger, you need at least one rigibody
    // For 2 solids, use OnCollision
    private void OnTriggerEnter(Collider other) {
        // less efficient code = if(other.gameObject.tag == "Player"){
        // more efficient code =
        // GameObject score = GameObject.FindGameObjectWithTag("Subway");
        // InventoryUI inventoryUI = score.GetComponent<InventoryUI>();

       if(other.CompareTag("Player")){
            // SceneManager.LoadScene(levelToLoad);
            SceneManager.LoadScene (levelToLoad);
        }
    }

// JK IDK WHY IT STOPPED WORKING
/* code below works, but I reorganized it so that it works at the subway station. if it's not all collected, nothing happens at the station */
// / Below is currently not working; 
// / I'm trying to create a scene transition where you can only pass to the subway scene if you have collected enough food items
// void Update()
// {
//     GameObject score = GameObject.FindGameObjectWithTag("Subway");
//     InventoryUI inventoryUI = score.GetComponent<InventoryUI>();
// //        //inventoryUI.prizeText();

//         if(other.CompareTag("Player")){
//         SceneManager.LoadScene("Street Scene");
//         if (inventoryUI.prizeText.text == "6")
//         {
//         SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
//         }
//     }

//     // Scene currentScene = SceneManager.GetActiveScene ();

//     //     string sceneName = currentScene.name;

//     //     if (sceneName == "Street Scene" && inventoryUI.prizeText.text == "6")
//     //     {
//     //         SceneManager.LoadScene("Subway Instructions");
//     //     }
        
// }

}
