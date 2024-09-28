using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.5f;
    public GameObject TimePlayer, SpacePlayer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += ProjectileDirection() * Time.deltaTime;
    }

    public Vector3 ProjectileDirection()
    {
        Vector3 displacementFromTime = TimePlayer.transform.position - transform.position;
        Vector3 displacementFromSpace = SpacePlayer.transform.position - transform.position;
        Vector3 TargetDirection;
        if (displacementFromTime.magnitude <= displacementFromSpace.magnitude)
        {
            TargetDirection = displacementFromTime.normalized;
        }
        else {
            TargetDirection = displacementFromSpace.normalized;
        }
        Vector3 Velocity = TargetDirection * speed;

        return Velocity;
    }

    private void OnTriggerEnter2D(Collider2D TriggerCollider)
    {
        Destroy(gameObject);

    }

}
