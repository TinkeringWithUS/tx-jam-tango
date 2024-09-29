using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speed = 3f;

    public Vector2 endPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate() {
        if (transform.position.x <= endPosition.x)
        {
            Vector3 rightVector = new Vector3(1, 0, 0);
            transform.position = transform.position + rightVector * speed * Time.deltaTime;
        }
    }
}
