using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActive : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Activate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("TimePlayer") || collision.gameObject.tag == ("SpacePlayer"))
        {
            foreach (var item in Activate)
            {
                item.SetActive(!item.activeSelf);
            }
            gameObject.SetActive(false);
        }
    }
}
