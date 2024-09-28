using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceAbilities : MonoBehaviour
{
    Rigidbody2D rb;

    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode teleportKey;

    private Vector2 lastDirection;
    public float teleportDistance;

    public int numAvailableTeleports;
    public float teleportCooldown;
    private bool canTeleport = true;

    bool gravityFlipped = false;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(rightKey)) {
            lastDirection = new Vector2(1, 0);
        } else if(Input.GetKey(leftKey)) {
            lastDirection = new Vector2(-1, 0);
        } else if(Input.GetKey(upKey)) {
            lastDirection = new Vector2(0, 1);
        } else if(Input.GetKey(downKey)) {
            lastDirection = new Vector2(0, -1);
        } else if(canTeleport && numAvailableTeleports > 0 && Input.GetKey(teleportKey)) {
            Vector2 teleportLocation = lastDirection * teleportDistance + rb.position;

            rb.position = teleportLocation;

            StartCoroutine(TeleportCooldownTimer());
            canTeleport = false;

            numAvailableTeleports--;
        }

        FlipGravity();

    } 

    private IEnumerator TeleportCooldownTimer() {
        yield return new WaitForSeconds(teleportCooldown);
        canTeleport = true;
    }

    public void FlipGravity()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (gravityFlipped == false)
            {
                gravityFlipped = true;
                Physics2D.gravity = new Vector2(3.0f, 0.0f);
                //rb.gravityScale *= -1;
            }
            else
            {
                gravityFlipped = false;
                Physics2D.gravity = new Vector2(-3.0f, 0.0f);
                //rb.gravityScale *= -1;
            }
        }
        print(gravityFlipped);
    }

    
}

