using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class BossFinal : MonoBehaviour
{
    public int health;
    private int currentHealth;
    public float vulnerabilityWindowSeconds = 2f;
    private bool isVulnerableToDamage = false;
    private bool isShotByTime = false;
    private bool isShotBySpace = false;
    
    private Shooting shooting;
    private Projectile projectile;

    public float percentSpeedIncrease = 1.1f;
    public float shootCoolDownDecreaseBuff = 0.9f;

    // Start is called before the first frame update
    void Start()
    {
        shooting = GetComponent<Shooting>();
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        
        if(collider.gameObject.GetComponent<SpaceAmmo>() != null) {
            if(!isShotBySpace) {
                // apply the boss buff 
                // make the boss track the players faster

                // projectile.speed *= percentSpeedIncrease;

                if (!isVulnerableToDamage) {
                    isVulnerableToDamage = true;
                    StartCoroutine(VulnerabilityTimer());
                }
            }
            isShotBySpace =  true;
        } else if(collider.gameObject.GetComponent<TimeAmmo>() != null) {
            if(!isShotByTime) {
                // apply the boss buff 
                shooting.attackCoolDown *= shootCoolDownDecreaseBuff;

                if (!isVulnerableToDamage) {
                    isVulnerableToDamage = true;
                    StartCoroutine(VulnerabilityTimer());
                }
            }
            isShotByTime = true;
        }

        if(isShotBySpace && isShotByTime && isVulnerableToDamage) {
            currentHealth -= 1;
            Vector3 scaling = transform.localScale * ((float)currentHealth / (float)health);
            Debug.Log("scaling x: " + scaling.x + ". scaling y: " + scaling.y + ". scaling z: " + scaling.z);
            transform.localScale = new Vector3(scaling.x, scaling.y, scaling.z);

            shooting.attackCoolDown *= 0.2f;
            isShotBySpace = false;
            isShotByTime = false;
            isVulnerableToDamage = false;

            if(currentHealth <= 0) {
                SceneManager.LoadScene("WinScene");                
            }
        }
    }

    private IEnumerator VulnerabilityTimer() {
        yield return new WaitForSeconds(vulnerabilityWindowSeconds);
        isVulnerableToDamage = false;
        isShotBySpace = false;
        isShotByTime = false;
    }
}
