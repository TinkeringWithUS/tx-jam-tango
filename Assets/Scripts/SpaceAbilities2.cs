using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceAbilities2 : MonoBehaviour
{
    Rigidbody2D rb;

    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode teleportKey;
    public KeyCode flipGravityKey;
    public float gravityStrength = 100.0f;
    private int currentGravDirection = 0;

    private Vector2 lastDirection;
    public float teleportDistance;

    public int numAvailableTeleports;
    public float teleportCooldown;
    private bool canTeleport = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(rightKey))
        {
            lastDirection = new Vector2(1, 0);
        }
        else if (Input.GetKey(leftKey))
        {
            lastDirection = new Vector2(-1, 0);
        }
        else if (Input.GetKey(upKey))
        {
            lastDirection = new Vector2(0, 1);
        }
        else if (Input.GetKey(downKey))
        {
            lastDirection = new Vector2(0, -1);
        }
        if (canTeleport && numAvailableTeleports > 0 && Input.GetKey(teleportKey))
        {
            Vector2 teleportLocation = lastDirection * teleportDistance + rb.position;

            rb.position = teleportLocation;

            StartCoroutine(TeleportCooldownTimer());
            canTeleport = false;

            numAvailableTeleports--;
        }

        FlipGravity();
    }

    private IEnumerator TeleportCooldownTimer()
    {
        yield return new WaitForSeconds(teleportCooldown);
        canTeleport = true;
    }

    public void FlipGravity()
    {
        Vector2[] gravityDirections = { new Vector2(0.0f, 1f), new Vector2(0.0f, -1.0f) };

        if (Input.GetKeyDown(flipGravityKey))
        {
            currentGravDirection = (currentGravDirection + 1) % gravityDirections.Length;

            Physics2D.gravity = gravityStrength * gravityDirections[currentGravDirection];

            GravityAffected[] gravityAffected = FindObjectsOfType<GravityAffected>();

            foreach (GravityAffected affected in gravityAffected)
            {
                affected.killVelocity();
            }
        }
    }
}
