using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    TimeFreezable timeFreezable;

    Vector2 direction;

    public float speed = 1.0f; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeFreezable = gameObject.GetComponent<TimeFreezable>();
        direction = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (timeFreezable.canChange())
        {
            rb.position += direction * speed * Time.fixedDeltaTime;
        }
    }
}
