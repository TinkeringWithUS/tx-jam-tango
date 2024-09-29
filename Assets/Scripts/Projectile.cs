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
    Vector2 Direction;
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
        }
        //transform.position += ProjectileDirection() * Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (timeFreezable.canChange())
        {
            rb.position += Direction * Time.fixedDeltaTime;
        }

    }

    public void Setdirection()
    {
        gameObject.SetActive(true);
        Direction = Trackplayer();
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
        if (triggerCollider.gameObject.tag == "TimePlayer" || triggerCollider.gameObject.tag == "SpacePlayer")
        {
            Debug.Log("collision tag = hazard detected");
            SceneManager.LoadScene(2);
        }

        gameObject.SetActive(false);
    }
}
