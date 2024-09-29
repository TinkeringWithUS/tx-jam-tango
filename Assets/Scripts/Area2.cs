using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area2 : MonoBehaviour
{
    public Transform NextArea;
    public Transform PreviousArea;
    public CameraMovement Camera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("TimePlayer") || collision.gameObject.tag == ("SpacePlayer"))
        {
            if (collision.transform.position.y < transform.position.y)
            {
                Camera.moveSection(NextArea);
            }
            else
            {
                Camera.moveSection(PreviousArea);
            }
        }
        print(collision.gameObject.tag);
    }
}
