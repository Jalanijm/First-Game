using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckARUnlock : MonoBehaviour
{
    public GameObject ARLocked;
    public GameObject ARUnlocked;

    void Start()
    {
        if (PlayerPrefs.GetInt("Goal 1") == 1)
        {
            ARUnlocked.SetActive(true);
            ARLocked.SetActive(false);
        } else
        {
            ARUnlocked.SetActive(false);
            ARLocked.SetActive(true);
        }
    }
}
