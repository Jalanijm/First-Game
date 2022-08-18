using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSkip : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
