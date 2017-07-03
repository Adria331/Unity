﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {

    Mob script;
    private int seconds = 1;
    private float time = 0;
    public GameObject MobPrefab;
    public GameObject[] punts = new GameObject[2];

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (time >= seconds)
        {
            createEnemy();
            seconds++;
        }
        time += Time.deltaTime;
    }

    void createEnemy()
    {
        GameObject enemy = Instantiate(MobPrefab, transform.position, transform.rotation) as GameObject;
        enemy.GetComponent<Mob>().punts = this.punts;
        enemy.GetComponent<Mob>().yo = enemy;
        enemy.GetComponent<Mob>().velo = 1;
    }
}
