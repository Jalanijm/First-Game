using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSettings : MonoBehaviour
{
    public int StageNumber;
    public int MaxKills;
    public GameObject StageClearMenu;

    public int StageClear1;
    public int StageClear2;
    public int StageClear3;
    public int StageClear4;

    void Start()
    {
        
    }

    void Update()
    {
        GameObject Tracker = GameObject.FindGameObjectWithTag("EnemiesKilled");
        var StageKills = Tracker.GetComponent<IntToText>().value;

        if (StageKills < MaxKills)
        {
            StageClearMenu.SetActive(false);
        }

        if(StageKills == MaxKills)
        {
            StageClearMenu.SetActive(true);
            Time.timeScale = 0f;
            PauseMenu.GameIsPaused = true;
            Cursor.visible = true;

            if (StageNumber == 1)
            {
                StageClear1 = 1;
                PlayerPrefs.SetInt("Stage 1", StageClear1);
            } 
            if (StageNumber == 2)
            {
                StageClear2 = 1;
                PlayerPrefs.SetInt("Stage 2", StageClear2);
            } 
            if (StageNumber == 3)
            {
                StageClear3 = 1;
                PlayerPrefs.SetInt("Stage 3", StageClear3);
            } 
            if (StageNumber == 4)
            {
                StageClear4 = 1;
                PlayerPrefs.SetInt("Stage 4", StageClear4);
            }
        }
    }
}
