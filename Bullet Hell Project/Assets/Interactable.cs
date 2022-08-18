using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
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

    public GameObject Stage2;
    public GameObject Stage2Locked;

    public GameObject Stage3;
    public GameObject Stage3Locked;

    public GameObject ShotgunDisplay;

    public GameObject NoShotgunDisplay;

    public Animator animator;

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
                animator.Play("PentaOn");
            }
        }
        else if (collider == null)
        {
            inRange = false;
            DisplayUI.SetActive(false);
            animator.Play("PentaIdle");
            
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
        if(PlayerPrefs.GetInt("Stage 1") == 1)
        {
            Stage2.SetActive(true);
            Stage2Locked.SetActive(false);

            ShotgunDisplay.SetActive(true);
            NoShotgunDisplay.SetActive(false);
        } else
        {
            Stage2.SetActive(false);
            Stage2Locked.SetActive(true);

            ShotgunDisplay.SetActive(false);
            NoShotgunDisplay.SetActive(true);
        }

        //Stage 2 Clear
        if (PlayerPrefs.GetInt("Stage 2") == 1)
        {
            Stage3.SetActive(true);
            Stage3Locked.SetActive(false);
        }
        else
        {
            Stage3.SetActive(false);
            Stage3Locked.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) && inRange == true && menuOpen == false)
        {
            menuOpen = true;
            
        } else if (Input.GetKeyDown(KeyCode.E) && inRange == true && menuOpen == true)
        {
            menuOpen = false;
            
        } else if (inRange == false)
        {
            menuOpen = false;
            DisplayUI.SetActive(false);
            animator.Play("PentaIdle");
        }

        if (menuOpen == true)
        {
            MenuUI.SetActive(true);
            DisplayUI.SetActive(false);
            Cursor.visible = true;
            animator.Play("PentaIdle");
        } else if (menuOpen == false && inRange == true)
        {
            MenuUI.SetActive(false);
            DisplayUI.SetActive(true);
           
        } else if (menuOpen == false)
        {
            MenuUI.SetActive(false);
            
        }

    }

    public void DemoMission()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Boss1()
    {
        SceneManager.LoadScene("Boss1");
    }

    public void Mission3()
    {
        SceneManager.LoadScene("Stage3");
    }

    public void MenuExit()
    {
        menuOpen = false;
    }
}
