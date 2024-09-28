using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    public float endXChange;
    private Vector2 startPoint;
    public Vector2 direction = new Vector2(1, 0);
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        startPoint = myRigidBody.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate() {
        // if not in valid x range of movement
        if(myRigidBody.position.x < startPoint.x || myRigidBody.position.x > startPoint.x + endXChange) {
            direction *= -1;
        }

        myRigidBody.position += direction * speed * Time.fixedDeltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        direction *= -1;
    }
}
