using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public ParticleSystem ShieldEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SlimeProjectile"))
        {
            ParticleSystem e = Instantiate(ShieldEffect);
            e.transform.position = transform.position;
        }

    }
}
