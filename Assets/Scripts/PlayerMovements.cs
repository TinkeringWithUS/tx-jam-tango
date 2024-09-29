using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerMovements : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10;
    public float jumpHeight = 10;
    Rigidbody2D myRigidBody;
    Vector2 velocity;

    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

    bool isGrounded = true;

    private TimeFreezable timeFreezable;

    //int coinCount;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        timeFreezable = GetComponent<TimeFreezable>(); 
        //transform.position = new Vector3(0, 10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"),0);
        Vector2 direction = new Vector2(0, 0);

        if(Input.GetKey(upKey) && isGrounded) {
            direction += new Vector2(0, 1) * jumpHeight;
        } else if(Input.GetKey(downKey)) {

        }
        if(Input.GetKey(leftKey)) {
            direction += new Vector2(-1, 0);
        } else if(Input.GetKey(rightKey)) {
            direction += new Vector2(1, 0);
        }

        velocity = direction * speed;

        if(!timeFreezable.canChange()) {
            velocity = new Vector2(0, 0);
        }
    }

    void FixedUpdate()
    {
        myRigidBody.position += velocity * Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Ground" || collider.gameObject.tag == "Door")
        {
            isGrounded = true;
        }

    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }

    }

}
