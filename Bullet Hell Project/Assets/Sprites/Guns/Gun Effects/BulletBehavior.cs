using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public ParticleSystem ImpactExplode;

    //Collision Behavior
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Breakable"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Walls"))
        {
            ParticleSystem e = Instantiate(ImpactExplode);
            e.transform.position = transform.position;
            Destroy(gameObject);
        }
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

    }


}
