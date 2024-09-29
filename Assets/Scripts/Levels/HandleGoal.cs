using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleGoal : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider2D) {
        if(collider2D.gameObject.tag == "TimePlayer" || collider2D.gameObject.tag == "SpacePlayer") {
            int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
            Debug.Log("active scene index: " + activeSceneIndex);
            SceneManager.LoadScene(activeSceneIndex + 1);
        }
    }
}