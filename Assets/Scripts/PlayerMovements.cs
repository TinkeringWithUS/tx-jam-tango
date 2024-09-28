using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10;
    Rigidbody2D myRigidBody;
    Vector2 velocity;
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
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"),0);
        Vector2 direction = input.normalized;
        velocity = direction * speed;
        Vector2 displacement = velocity * Time.deltaTime;

        //transform.position += displacement;
        //transform.Translate(displacement); 
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
