using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckShotgun : MonoBehaviour
{
    public GameObject ShotgunUnlock;
    public GameObject ShotgunLocked;

    public GameObject ARUnlocked;
    
    void Start()
    {
        if (PlayerPrefs.GetInt("Stage 1") == 1 && PlayerPrefs.GetInt("Goal 1") == 0)
        {
            ShotgunUnlock.SetActive(true);
            ShotgunLocked.SetActive(false);
            ARUnlocked.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Goal 1") == 1)
        {
            ShotgunUnlock.SetActive(false);
            ARUnlocked.SetActive(true);
            ShotgunLocked.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Stage 1") == 0 && PlayerPrefs.GetInt("Goal 1") == 0)
        {
            ShotgunUnlock.SetActive(false);
            ARUnlocked.SetActive(false);
            ShotgunLocked.SetActive(true);
        }
    }
}