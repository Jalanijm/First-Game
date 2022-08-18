using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellyDetection : MonoBehaviour
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
    bool isShot = false;

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
            GetComponent<SkellyAI>().enabled = true;
            GetComponent<SkellyAI>().SkellyMove.Play("SkellyMovement");
        }
        else if (collider = null)
        {
            GetComponent<SkellyAI>().SkellyMove.Play("SkellyIdle");
            GetComponent<SkellyAI>().enabled = false;
        }
        else if (isShot == true)
        {
            GetComponent<SkellyAI>().enabled = true;
            GetComponent<SkellyAI>().SkellyMove.Play("SkellyMovement");
        }
        else if (isShot == false)
        {
            GetComponent<SkellyAI>().SkellyMove.Play("SkellyIdle");
            GetComponent<SkellyAI>().enabled = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            GetComponent<SkellyAI>().enabled = true;
            isShot = true;
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
}
