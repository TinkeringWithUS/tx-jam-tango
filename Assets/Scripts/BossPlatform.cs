using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlatform : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector2 leftVector = new Vector2(-1, 0f);
        rb.position += speed * leftVector * Time.deltaTime;
    }
}
