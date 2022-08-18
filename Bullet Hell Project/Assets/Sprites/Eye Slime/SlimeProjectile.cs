using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeProjectile : MonoBehaviour
{
    public float speed;

    public ParticleSystem SlimeExplode;
    private Transform player;
    private Vector2 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerFullBody").transform;

        target = new Vector2(player.position.x, player.position.y);

    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject, 5);
    }

    public void DestroyProjectileInstant()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }

    }



}
