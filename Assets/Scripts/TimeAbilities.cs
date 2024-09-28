using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAbilities : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] snapshots;
    Vector3 ScaleSnapShot;
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        TimeSnapshot();
    }

    public void TimeSnapshot()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            snapshots[0].transform.position = transform.position;
            ScaleSnapShot = transform.localScale;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.transform.position = snapshots[0].transform.position;
            gameObject.transform.localScale = ScaleSnapShot;
        }
    }
}
