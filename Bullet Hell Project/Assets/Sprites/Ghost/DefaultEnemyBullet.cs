using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemyBullet : MonoBehaviour
{
    private Vector2 moveDirection;
    public float moveSpeed;

    private void OnEnable()
    {
        Invoke("Destroy", 4f);
    }

    void Start()
    {
        moveSpeed = 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shield"))
        {
            gameObject.SetActive(false);
        }

    }

}
