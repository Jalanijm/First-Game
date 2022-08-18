using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneProjectile : MonoBehaviour
{
    public float speed;

    public ParticleSystem SlimeExplode;
    public Transform player;

    Rigidbody2D rb;

    Vector2 moveDirection;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("PlayerFullBody").transform;

        rb = GetComponent<Rigidbody2D>();

        transform.position = transform.position;

        speed = 20;

        moveDirection = (player.transform.position - transform.position).normalized * speed;

        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);

        DestroyProjectile();
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
        if (other.CompareTag("PlayerFullBody"))
        {
            DestroyProjectileInstant();
        }

    }



}
