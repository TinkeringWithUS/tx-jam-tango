using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    Vector3 velocity = Vector3.zero;
    private Vector2 currentPos;
    public GameObject Player1, Player2;
    //Transform camPos;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3((Player1.transform.position.x + Player2.transform.position.x) / 2, (Player1.transform.position.y + Player2.transform.position.y) / 2, -1);
    }

    // Update is called once per frame
    void Update()
    {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPos.x, currentPos.y, transform.position.z), ref velocity, speed);
    }

    public void moveSection(Transform newArea)
    {
        currentPos = newArea.position;
    }
}
