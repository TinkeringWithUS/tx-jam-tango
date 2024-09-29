using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimeAmmo : MonoBehaviour
{
    public float speed = 1.5f;
    public GameObject finalBoss;
    Rigidbody2D rb;
    TimeFreezable timeFreezable;
    Vector2 direction;

    bool isActive = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeFreezable = gameObject.GetComponent<TimeFreezable>();

        finalBoss = FindObjectOfType<BossFinal>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (isActive && timeFreezable.canChange())
        {
            rb.position += direction * Time.fixedDeltaTime;
        }

    }

    public void Setdirection()
    {
        direction = Trackplayer();
    }

    public Vector2 Trackplayer()
    {
        Vector2 displacementFromBoss = finalBoss.transform.position - transform.position;

        Vector2 TargetDirection = displacementFromBoss.normalized;

        Vector2 Velocity = TargetDirection * speed;

        return Velocity;
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if(triggerCollider.gameObject.GetComponent<PlayerMovements>() != null) {
            Setdirection();
            isActive = true;
        }

        if(triggerCollider.gameObject.GetComponent<BossFinal>() != null) {
            Destroy(gameObject);
        }

        // phase through the boss platform
        // if(triggerCollider.GetComponent<BossPlatform>() != null) {
        //     gameObject.SetActive(false);
        // }
    }
}


