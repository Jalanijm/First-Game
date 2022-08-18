using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public ParticleSystem ImpactExplode;
    public float HP = 1;
    public GameObject Drop;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HP--;

        } else if (other.CompareTag("Bullet"))
        {
            HP--;
        }
    }

    private void Update()
    {
        if(HP <= 0)
        {
            ParticleSystem e = Instantiate(ImpactExplode);
            e.transform.position = transform.position;

            GameObject d = Instantiate(Drop);
            d.transform.position = transform.position;
            var Sound = GameObject.FindGameObjectWithTag("SoundEffects").GetComponent<SoundEffects>();
            Sound.BreakSound.Play();
            Destroy(gameObject);
        }
    }


}
