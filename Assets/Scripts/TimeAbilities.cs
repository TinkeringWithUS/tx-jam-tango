using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;
using UnityEngine.UI;

public class TimeAbilities : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode freezeKey;

    public GameObject[] snapshots;
    Vector3 ScaleSnapShot;


    public Slider freezeLeftSlider;
    public float freezeAmountLeftSeconds;
    private float maxFreezeAmountSeconds;
    private float freezeStart;
    
    void Start()
    {

        freezeLeftSlider.value = freezeLeftSlider.maxValue;
        maxFreezeAmountSeconds = freezeAmountLeftSeconds;
    }
    
    // Update is called once per frame
    void Update()
    {
        bool shouldFreeze = false;

        if(Input.GetKey(freezeKey)) {
            shouldFreeze = true;
        }

        TimeFreeze(shouldFreeze);

        TimeSnapshot();
    }

    public void TimeFreeze(bool shouldFreeze) {
        TimeFreezable[] freezables = FindObjectsOfType<TimeFreezable>(); 

        foreach (TimeFreezable freezableObj in freezables) {

            if (shouldFreeze && freezeAmountLeftSeconds > 0) {
                freezableObj.TimeFreeze();
            } else {
                freezableObj.TimeUnfreeze();
            }
        }


        if (shouldFreeze) {
            freezeAmountLeftSeconds -= Time.deltaTime;
        }

        freezeLeftSlider.value = (freezeAmountLeftSeconds / maxFreezeAmountSeconds) * freezeLeftSlider.maxValue;
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
