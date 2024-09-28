using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class HomingProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.5f;
    public GameObject TimePlayer, SpacePlayer;
    Rigidbody2D rb;
    TimeFreezable timeFreezable;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeFreezable = gameObject.GetComponent<TimeFreezable>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += ProjectileDirection() * Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (timeFreezable.canChange())
        {
            rb.position += ProjectileDirection() * Time.fixedDeltaTime;
        }

    }

    public Vector2 ProjectileDirection()
    {
        Vector2 displacementFromTime = TimePlayer.transform.position - transform.position;
        Vector2 displacementFromSpace = SpacePlayer.transform.position - transform.position;
        Vector2 TargetDirection;
        if (displacementFromTime.magnitude <= displacementFromSpace.magnitude)
        {
            TargetDirection = displacementFromTime.normalized;
        }
        else {
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

        Destroy(gameObject);
    }
}
