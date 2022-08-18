using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyType;
    public Animation Animation;
    public float StartUpTime;

    private void Start()
    {
        FunctionTimer.Create(StartUp, StartUpTime);
    }

    private void StartUp()
    {
        Animation.Play();
        FunctionTimer.Create(SpawnEnemy, 2.1f);
        FunctionTimer.Create(DeleteSelf, 4f);
        

        void SpawnEnemy()
        {
            Instantiate(EnemyType, transform.position, Quaternion.identity);

        }

        void DeleteSelf()
        {
            Destroy(gameObject);
        }
    }

}
