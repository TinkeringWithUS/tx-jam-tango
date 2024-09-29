using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public Transform NextArea;
    public Transform PreviousArea;
    public CameraMovement Camera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("TimePlayer") || collision.gameObject.tag == ("SpacePlayer")) ;
        {
            if (collision.transform.position.x < transform.position.x)
            {
                Camera.moveSection(NextArea);
            }
            else {
                Camera.moveSection(PreviousArea);
            }
        }
    }
}
