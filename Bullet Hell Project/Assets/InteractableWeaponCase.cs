 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWeaponCase : MonoBehaviour
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

    public GameObject NoShotgun;
    public GameObject YesShotgun;

    public GameObject NoAR;
    public GameObject YesAR;

    public GameObject DisplayAR;
    public GameObject NoDisplayAR;

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

        //Stage 1 Clear
        if (PlayerPrefs.GetInt("Stage 1") == 1)
        {
            YesShotgun.SetActive(true);
            NoShotgun.SetActive(false);
        }
        else
        {
            YesShotgun.SetActive(false);
            NoShotgun.SetActive(true);
        }

        //Stage SurvivalGoal Clear
        if (PlayerPrefs.GetInt("Goal 1") == 1)
        {
            YesAR.SetActive(true);
            NoAR.SetActive(false);

            DisplayAR.SetActive(true);
            NoDisplayAR.SetActive(false);
        }
        else
        {
            YesAR.SetActive(false);
            NoAR.SetActive(true);

            DisplayAR.SetActive(false);
            NoDisplayAR.SetActive(true);
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
            DisplayUI.SetActive(false);
            Cursor.visible = true;
            
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

  

    public void MenuExit()
    {
        menuOpen = false;
    }
}
