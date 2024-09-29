using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // public float phaseTime;
    public float spawnLength = 5f;
    public float phaseLength = 5f;
    private bool phaseDone = true;
    public GameObject lineProjectilePrefab;
    public int numLineProjectiles = 5;

    public GameObject timeAmmoPrefab;
    public GameObject spaceAmmoPrefab;

    public Vector2 spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpaceAmmo spaceAmmo = FindObjectOfType<SpaceAmmo>();
        TimeAmmo timeAmmo = FindObjectOfType<TimeAmmo>();
        // if(phaseDone) {
        //     StartCoroutine(PhaseTimer());
        // }
        // straightLinePhase();

        if(spaceAmmo == null && timeAmmo == null) {
            // respawn the ammmos in a random place
            // camera x viewport is from [-10, 10] 
            // y is from [-3, 4.5]
            System.Random rand = new System.Random();
            

            float randomYTimeAmmo = (float)(rand.NextDouble() * 7.5 - 3);
            float randomXTimeAmmo = (float)(rand.NextDouble() * 10 - 10);

            float randomYSpaceAmmo = (float)(rand.NextDouble() * 7.5 - 3);
            float randomXSpaceAmmo = (float)(rand.NextDouble() * 10 - 10);

            Vector3 timeLocation = new Vector3(randomXTimeAmmo, randomYTimeAmmo, 0);
            Vector3 spaceLocation = new Vector3(randomXSpaceAmmo, randomYSpaceAmmo, 0);

            Instantiate(timeAmmoPrefab, timeLocation, Quaternion.identity);
            Instantiate(spaceAmmoPrefab, spaceLocation, Quaternion.identity);
            
        }
    }

    private IEnumerator PhaseTimer() {
        yield return new WaitForSeconds(phaseLength);
        phaseDone = true;
    }

    private void straightLinePhase() {
        SpawnTimer(numLineProjectiles);
    }


    private IEnumerator SpawnTimer(int projectileNumber) {
        for (int projectile = 0; projectile < numLineProjectiles; projectile++)
        {
            yield return new WaitForSeconds(spawnLength);
            float spawnRotationIncrements = 90f / numLineProjectiles;
            // Instantiate(lineProjectilePrefab, spawnLocation, Quaternion.Euler(new Vector3(0, projectileNumber * spawnRotationIncrements, 0)));
            Instantiate(lineProjectilePrefab, spawnLocation, transform.rotation);
        }
    }
}
