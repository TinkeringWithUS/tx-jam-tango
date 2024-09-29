using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.WSA;

public class Projectile : MonoBehaviour
{
    public float speed = 1.5f;
    public GameObject TimePlayer, SpacePlayer;
    Rigidbody2D rb;
    TimeFreezable timeFreezable;
    Vector2 direction;
    public float lifeSpan = 2;
    float lifeSpanCounter = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeFreezable = gameObject.GetComponent<TimeFreezable>();
    }

    private void OnEnable()
    {
        //Setdirection();
    }
    // Update is called once per frame
    void Update()
    {
        lifeSpanCounter += Time.deltaTime;
        if (lifeSpanCounter >= lifeSpan) { 
            gameObject.SetActive(false);
            Debug.Log("set active called due to lifespan, active in hierarchy of projectile: " + gameObject.activeInHierarchy);
            lifeSpanCounter = 0;
        }
        //transform.position += ProjectileDirection() * Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (timeFreezable.canChange())
        {
            rb.position += direction * Time.fixedDeltaTime;
        }

    }

    public void Setdirection()
    {
        gameObject.SetActive(true);
        Debug.Log("Set direction called on projectile, active in hierarchy: " + gameObject.activeInHierarchy);
        direction = Trackplayer();
    }

    public Vector2 Trackplayer()
    {
        Vector2 displacementFromTime = TimePlayer.transform.position - transform.position;
        Vector2 displacementFromSpace = SpacePlayer.transform.position - transform.position;
        Vector2 TargetDirection;
        if (displacementFromTime.magnitude <= displacementFromSpace.magnitude)
        {
            TargetDirection = displacementFromTime.normalized;
        }
        else
        {
            TargetDirection = displacementFromSpace.normalized;
        }
        Vector2 Velocity = TargetDirection * speed;

        return Velocity;
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        HazardBehavior.hazardBehavior(triggerCollider);

        // phase through the boss platform
        // if(triggerCollider.GetComponent<BossPlatform>() != null) {
        //     gameObject.SetActive(false);
        //
    }
}
