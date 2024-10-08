using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;
using UnityEngine.UI;

public class TimeAbilities : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode freezeKey;
    public KeyCode snapshotKey = KeyCode.DownArrow;
    public KeyCode rewindKey = KeyCode.Space;


    public GameObject[] snapshots;
    Vector3 ScaleSnapShot;
    bool shouldFreeze = false;


    public Slider freezeLeftSlider;
    public float freezeAmountLeftSeconds;
    private float maxFreezeAmountSeconds;

    public PlayerMovements playerMovements;
    
    void Start()
    {
        if(freezeLeftSlider != null) {
            freezeLeftSlider.value = freezeLeftSlider.maxValue;
        }
        maxFreezeAmountSeconds = freezeAmountLeftSeconds;
        playerMovements = GetComponent<PlayerMovements>();
    }
    
    // Update is called once per frame
    void Update()
    {
        shouldFreeze = false;

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

        if(freezeLeftSlider != null) {
            freezeLeftSlider.value = (freezeAmountLeftSeconds / maxFreezeAmountSeconds) * freezeLeftSlider.maxValue;
        }
    }

    public void TimeSnapshot()
    {
        if (Input.GetKeyDown(snapshotKey))
        {
            snapshots[0].transform.position = transform.position;
            ScaleSnapShot = transform.localScale;
        }
        if (Input.GetKeyDown(rewindKey))
        {
            gameObject.transform.position = snapshots[0].transform.position;
            gameObject.transform.localScale = ScaleSnapShot;

            playerMovements.isGrounded = true;
        }
    }

    public bool GetshouldFreeze()
    {
        return shouldFreeze;
    }
}
