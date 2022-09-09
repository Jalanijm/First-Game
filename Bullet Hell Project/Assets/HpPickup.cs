using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           if (GameObject.FindWithTag("Player").GetComponent<AttachPoint>().Hitpoints < GameObject.FindWithTag("Player").GetComponent<AttachPoint>().MaxHitpoints)
            {
                Destroy(gameObject);
            }
            
        }
    }

}
