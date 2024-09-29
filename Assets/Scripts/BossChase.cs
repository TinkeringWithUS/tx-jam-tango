using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;


public class BossChase : MonoBehaviour
{
    public GameObject Timeplayer, Spaceplayer;
    public float speed = 1.0f;
    public Transform PathHolder;
    public GameObject[] CheckPointsHolder;
    int Mark = 1;
    Vector3[] waypoints = new Vector3[1];
    public bool pointReached = true;

    // Start is called before the first frame update
    void Start()
    {
        //PathHolder = gameObject.transform.GetChild(0).transform;
        waypoints = new Vector3[PathHolder.childCount];
        {
            for (int i = 0; i < waypoints.Length; i++)
            {
                waypoints[i] = PathHolder.GetChild(i).position;
                //waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Vector3 startPosition = PathHolder.GetChild(0).position;
        Vector3 previousPosition = startPosition;

        foreach (Transform waypoint in PathHolder)
        {
            Gizmos.DrawSphere(waypoint.position, 0.3f);
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }

    }

    public void Move(Vector3[] waypoints)
    {
        if (Mark < waypoints.Count())
        {
            Vector3 distance = waypoints[Mark] - transform.position;
            Vector3 direction = distance.normalized;
            gameObject.transform.position += direction * speed * Time.deltaTime;

            if ((waypoints[Mark] - transform.position).magnitude <= 1.0f)
            {
                Mark++;
            }
        }
    }

    /*
    public void PlayerReachedPoints()
    {
       
    }
    */
    // Update is called once per frame
    void Update()
    {
        Move(waypoints);
    }


}
