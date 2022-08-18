using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellyCheck : MonoBehaviour
{
    public GameObject SkellyPet;

    void Start()
    {
        if (PlayerPrefs.GetInt("Goal 2") == 1)
        {
            SkellyPet.SetActive(true);
        }
        else
        {
            SkellyPet.SetActive(false);
        }
    }
}
