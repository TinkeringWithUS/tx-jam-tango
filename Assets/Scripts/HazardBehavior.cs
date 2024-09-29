using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        hazardBehavior(triggerCollider);
    }

    public static void hazardBehavior(Collider2D collider) {
        if (collider.gameObject.tag == "TimePlayer" || collider.gameObject.tag == "SpacePlayer")
        {
            Debug.Log("collision tag = hazard detected");
            SceneManager.LoadScene("LoseScene");
        }
    }
}
