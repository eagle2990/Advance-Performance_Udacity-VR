﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    public static BallSpawner current;

    public GameObject pooledBall; //the prefab of the object in the object pool
    public int ballsAmount = 20; //the number of objects you want in the object pool
    public List<GameObject> pooledBalls; //the object pool
    public static int ballPoolNum = 0; //a number used to cycle through the pooled objects

    private float cooldown;
    private float cooldownLength = 0.5f;

    void Awake()
    {
        current = this; //makes it so the functions in ObjectPool can be accessed easily anywhere
    }

    void Start()
    {
        //Create Bullet Pool     
        cooldown = cooldownLength;
        if (pooledBalls == null)
            pooledBalls = new List<GameObject>(GameObject.FindGameObjectsWithTag("Throwable"));

        if (pooledBalls.Count == 0)
        {
            for (int i = 0; i < ballsAmount; i++)
            {
                GameObject obj = Instantiate(pooledBall);
                obj.SetActive(false);
                pooledBalls.Add(obj);
            }
        }
        else
        {
            ballsAmount = pooledBalls.Count;
        }
    }

    public GameObject GetPooledBall()
    {

        while (pooledBalls[ballPoolNum].activeInHierarchy)
        {
            ballPoolNum++;
            if (ballPoolNum >= (ballsAmount - 1))
            {
                ballPoolNum = 0;
            }
        }
        return pooledBalls[ballPoolNum];
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            cooldown = cooldownLength;
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        GameObject selectedBall = GetPooledBall();
        selectedBall.transform.position = transform.position;
        selectedBall.SetActive(true);
        selectedBall.GetComponent<Rigidbody>().WakeUp();
    }
}
