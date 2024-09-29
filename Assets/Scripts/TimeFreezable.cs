using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreezable : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 beforeFreezeVelocity;

    bool isFrozen = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TimeFreeze() {
        if(!isFrozen && gameObject.GetComponent<TimeAbilities>() == null) {
            beforeFreezeVelocity = rb.velocity;

            rb.constraints = RigidbodyConstraints2D.FreezeAll;

            isFrozen = true;
        }
    }

    public void TimeUnfreeze() {
        if (isFrozen && gameObject.GetComponent<TimeAbilities>() == null) {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            rb.velocity = beforeFreezeVelocity;

            isFrozen = false;
        }
    }

    public bool canChange() {
        // exclude time player from freezing
        if(gameObject.GetComponent<TimeAbilities>() != null) {
            return true;
        }
        return !isFrozen;
    }
}
