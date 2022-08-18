using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableExit : MonoBehaviour
{
    [Header("OverlapBox parameters")]
    [SerializeField]
    private Transform detectorOrigin;
    public Vector2 detectorSize = Vector2.one;
    public Vector2 detectorOriginOffset = Vector2.zero;

    public float detectionDelay = 0.2f;

    public LayerMask detectorLayerMask;

    [Header("Gizmo parameters")]
    public Color gizmoIdleColor = Color.green;
    public Color gizmoDetectedColor = Color.red;
    public bool showGizmos = true;
    bool inRange = false;
    bool menuOpen = false;

    public GameObject MenuUI;
    public GameObject DisplayUI;

    public GameObject Area2Unlocked;
    public GameObject Area2Locked;

    public GameObject Survival2;
    public GameObject Survival3;

    private void Start()
    {
        StartCoroutine(DetectionCoroutine());
    }

    IEnumerator DetectionCoroutine()
    {
        yield return new WaitForSeconds(detectionDelay);
        PerformDetection();
        StartCoroutine(DetectionCoroutine());
    }

    public void PerformDetection()
    {
        Collider2D collider = Physics2D.OverlapBox((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize, 0, detectorLayerMask);

        if (collider != null)
        {
            inRange = true;
            if (menuOpen == false && inRange == true)
            {
                DisplayUI.SetActive(true);
                
            }
        }
        else if (collider == null)
        {
            inRange = false;
            DisplayUI.SetActive(false);
            

        }
    }


    private void OnDrawGizmos()
    {
        if (showGizmos && detectorOrigin != null)
        {
            Gizmos.color = gizmoIdleColor;
            Gizmos.DrawCube((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize);
        }
    }
    void Update()
    {
        PlayerPrefs.GetInt("Stage 1");
        PlayerPrefs.GetInt("Stage 2");
        PlayerPrefs.GetInt("Stage 3");
        PlayerPrefs.GetInt("Stage 4");

        //Stage 3 Clear
        if (PlayerPrefs.GetInt("Stage 3") == 1)
        {
            Area2Unlocked.SetActive(true);
            Area2Locked.SetActive(false);
            Survival2.SetActive(true);
            Survival3.SetActive(true);
        }
        else
        {
            Area2Unlocked.SetActive(false);
            Area2Locked.SetActive(true);
            Survival2.SetActive(false);
            Survival3.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && inRange == true && menuOpen == false)
        {
            menuOpen = true;

        }
        else if (Input.GetKeyDown(KeyCode.E) && inRange == true && menuOpen == true)
        {
            menuOpen = false;

        }
        else if (inRange == false)
        {
            menuOpen = false;
            DisplayUI.SetActive(false);
            
        }

        if (menuOpen == true)
        {
            MenuUI.SetActive(true);
            Cursor.visible = true;
            DisplayUI.SetActive(false);
           
        }
        else if (menuOpen == false && inRange == true)
        {
            MenuUI.SetActive(false);
            DisplayUI.SetActive(true);
        }
        else if (menuOpen == false)
        {
            MenuUI.SetActive(false);
        }

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SurvivalZone1()
    {
        SceneManager.LoadScene("Survival1");
    }

    public void SurvivalZone2()
    {
        SceneManager.LoadScene("S2");
    }

    public void SurvivalZone3()
    {
        SceneManager.LoadScene("S3");
    }

    public void Area1()
    {
        SceneManager.LoadScene("Base");
    }

    public void MenuExit()
    {
        menuOpen = false;
    }
}
