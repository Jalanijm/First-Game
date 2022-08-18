using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntToText : MonoBehaviour
{
    public int value = 0;
    public float TimerValue = 0;
    public Text ValueText;
    public Text TimerText;
    public int CheckEnemyCount = 0;

    public Text DeathTimer;
    public Text DeathKills;

    public Text StageClearTimer;
    public Text StageClearKills;

    void Start()
    {
        TimerValue = 0;
        value = 0;
    }

    public void AddOne()
    {
        value++;
        if (CheckEnemyCount == 1)
        {
            GameObject.FindGameObjectWithTag("SurvivalSp").GetComponent<SurvivalSpawner>().enemyCount -= 1;

        }

        return;
    }

    void Update()
    {
        ValueText.text = value.ToString("Kills: 0");
        TimerText.text = TimerValue.ToString("Time: 0.00");

        DeathTimer.text = TimerValue.ToString("Time: 0.00");
        DeathKills.text = value.ToString("Kills: 0");

        StageClearTimer.text = TimerValue.ToString("Time: 0.00");
        StageClearKills.text = value.ToString("Kills: 0");
    }

    private void FixedUpdate()
    {
        TimerValue += 1 * Time.deltaTime;
    }
}
