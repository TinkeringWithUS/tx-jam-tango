using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private SpawnManager spawnManager;
    private Shooting shooting;

    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        shooting = FindObjectOfType<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
