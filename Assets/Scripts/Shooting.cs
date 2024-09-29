using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float attackCoolDown = 1.0f;
    float coolDownTimer = Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (coolDownTimer > attackCoolDown)
        {
            Shoot();
            coolDownTimer = 0;
        }
    }

    void Shoot()
    { 
        
    }
}
