using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpaceAmmoCollector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        // if it is a collectible, destroy it
        if(collider.GetComponent<Collectible>() != null) {
            Destroy(collider.gameObject);
        }
    }
}
