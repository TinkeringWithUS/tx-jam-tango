using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //int coinCount;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        //transform.position = new Vector3(0, 10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"),0);
        Vector2 direction = new Vector2(0, 0);

        if(Input.GetKey(upKey)) {
            direction += new Vector2(0, 1) * jumpHeight;
        } else if(Input.GetKey(downKey)) {

        } else if(Input.GetKey(leftKey)) {
            direction = new Vector2(-1, 0);
        } else if(Input.GetKey(rightKey)) {
            direction = new Vector2(1, 0);
        }

        velocity = direction * speed;
    }

    public Vector2 playerInputCheck()
    {
       Vector2 inputPlayer1 = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
       Vector2 inputPlayer2 = new Vector2(Input.GetAxisRaw("Horizontal2"), 0);

        if (gameObject.tag == "TimePlayer")
        {
            return inputPlayer1;
        }
        else
        {
            return inputPlayer2;
        }
    }

    void FixedUpdate()
    {
        myRigidBody.position += velocity * Time.fixedDeltaTime;
    }
}
