using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTimeLimit : MonoBehaviour
{
    public float TimeLimit;

    void Update()
    {
        GameObject Tracker = GameObject.FindGameObjectWithTag("EnemiesKilled");
        var StageTime = Tracker.GetComponent<IntToText>().TimerValue;

        GameObject PlayerBody = GameObject.FindGameObjectWithTag("Player");
        

        if (StageTime >= TimeLimit)
        {
            PlayerBody.GetComponent<AttachPoint>().TakeHit(100);
            Debug.Log("Time up");
        }
    }
}
