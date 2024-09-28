using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipGravityChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spacePlayer;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
