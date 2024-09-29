using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float attackCoolDown = 1.0f;
    public Transform firePoint;
    // public GameObject TimePlayer, SpacePlayer;
    // public int numBalls;
    public GameObject ballPrefab;
    public GameObject[] balls;
    float coolDownTimer = Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        // balls = new GameObject[numBalls];

        // for(int ball = 0; ball < numBalls; ball++) {
        //     balls[ball] = Instantiate(ballPrefab, transform); 
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (coolDownTimer > attackCoolDown)
        {
            Shoot();
            coolDownTimer = 0;
        }

        coolDownTimer += Time.deltaTime;
    }

    void Shoot()
    {
        balls[findBall()].transform.position = firePoint.position;
        balls[findBall()].GetComponent<Projectile>().Setdirection();
    }

    private int findBall()
    {
        for (int i = 0; i < balls.Length; i++)
        {
            if (!balls[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
