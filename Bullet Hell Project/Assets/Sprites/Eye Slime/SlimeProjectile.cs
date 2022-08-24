using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeProjectile : MonoBehaviour
{
    public float speed;

    public ParticleSystem SlimeExplode;
    private Transform playerTransform;
    private Vector2 target;

    public GameObject[] Player;

    void Start()
    {


        Player = GameObject.FindGameObjectsWithTag("PlayerFullBody");

        playerTransform = Player[0].transform;

        target = new Vector2(playerTransform.position.x, playerTransform.position.y);

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
