using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttachPoint : MonoBehaviour
{
    public float moveSpeed = 5f;
    public static bool isRunning;
    public static bool usingShield;
    private Vector2 MoveDirection;

    public GameObject Pistol;
    public GameObject ShotgunGun;
    public GameObject Shield;

    public Rigidbody2D rb;
    public Animator animator;

    public int Hitpoints;
    public int MaxHitpoints = 5;
    public HealthBar healthBar;
    
    public ParticleSystem DamageEffect;

    public ScreenShake cameraShake;

    Vector2 movement;

    private void Start()
    {
        //Hitpoints
        Hitpoints = MaxHitpoints;
        healthBar.SetMaxHealth(MaxHitpoints);

        usingShield = false;
      
    }

     

    //Take Damage and Shake Camera
    public void TakeHit(int damage)
    {
        StartCoroutine(cameraShake.Shake(.1f, .25f));

        Hitpoints -= damage;
        healthBar.SetHealth(Hitpoints);

        var Sound = GameObject.FindGameObjectWithTag("SoundEffects").GetComponent<SoundEffects>();
        Sound.HitEffect.Play();

        if (Hitpoints <= 0)
        {
            Debug.Log("Dead");
            PauseMenu.PlayerIsDead = true;
        }
    }

    public void Heal(int damage)
    {
        if (Hitpoints < MaxHitpoints)
        {
            Hitpoints += damage;
            healthBar.SetHealth(Hitpoints);

            var Sound = GameObject.FindGameObjectWithTag("SoundEffects").GetComponent<SoundEffects>();
            Sound.HpEffect.Play();

        }
      
    }

    void ProcessInputs()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        MoveDirection = new Vector2(movement.x, movement.y).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

        //Sprint
        if (isRunning)
        {
           moveSpeed = 8.5f;
        } else
        {
            moveSpeed = 5f;
        }

        if (usingShield)
        {
            Shield.SetActive(true);
        }else
        {
            Shield.SetActive(false);
        }

        if(PlayerPrefs.GetInt("Stage 2") == 1)
        {
            MaxHitpoints = 7;
        } else
        {
            MaxHitpoints = 5;
        }

    }

    private void Move()
    {
        //Movement
        rb.velocity = new Vector2(MoveDirection.x * moveSpeed, MoveDirection.y * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject body = GameObject.FindWithTag("PlayerFullBody");

        if (other.CompareTag("SlimeProjectile"))
        {
            TakeHit(1);
            ParticleSystem e = Instantiate(DamageEffect);
            e.transform.position = body.transform.position;
        }
        if (other.CompareTag("HpUp"))
        {
            Heal(1);
        }

    }

    void FixedUpdate()
    {
        Move();

    }
}
