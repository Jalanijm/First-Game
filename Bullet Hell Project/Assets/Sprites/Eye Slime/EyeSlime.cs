using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Events;
using UnityEngine.UI;

public class EyeSlime : MonoBehaviour
{
    public Transform target;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public int Hitpoints;
    public int MaxHitpoints = 7;

    private float setSpeed;

    public Text ValueText;
    public HealthBar healthBar;

    public Transform enemyGFX;

    public ParticleSystem SlimeExplode;
    public ParticleSystem Slimedust;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPAth = false;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    public GameObject Tracker;

    public GameObject[] Player;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .1f);
        Hitpoints = MaxHitpoints;
        healthBar.SetMaxHealth(MaxHitpoints);

        FindTarget();

        timeBtwShots = startTimeBtwShots;

        setSpeed = speed;
    }

    public void FindTarget()
    {
        GameObject[] Player = GameObject.FindGameObjectsWithTag("PlayerFullBody");
        target = Player[0].transform;
    }

    //Bullet Detect and Blood Effect
    public void TakeHit(int damage)
    {
        Hitpoints -= damage;
        healthBar.SetHealth(Hitpoints);
        ParticleSystem e = Instantiate(SlimeExplode);
        e.transform.position = transform.position;

        //Kill Tracker
        Tracker = GameObject.FindGameObjectWithTag("EnemiesKilled");

        if (Hitpoints == 0)
        {
            Tracker.GetComponent<IntToText>().AddOne();
            var Sound = GameObject.FindGameObjectWithTag("SoundEffects").GetComponent<SoundEffects>();
            Sound.EnemyHurt.Play();
            Destroy(gameObject);
        }
    }

    //Path Find
    void UpdatePath()
    {
        if (seeker.IsDone())
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    //Damage Player and Blood Effect
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.collider.GetComponent<AttachPoint>();
        if (player)
        {
            player.TakeHit(1);
            ParticleSystem e = Instantiate(SlimeExplode);
            e.transform.position = target.position;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bullet"))
        {
            TakeHit(1);
        }

        if(other.CompareTag("Flashlight")) {
            if(setSpeed >= 600)
            {
                speed = 500f;
            }
        } else
        {
            speed = setSpeed;
        }
    }


    public void CreateSlimedust()
    {
        Slimedust.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPAth = true;
            return;
        } else
        {
            reachedEndOfPAth = false;
        }

        //Movement
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        
        rb.AddForce(force);
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        //Direction Facing
        if (rb.velocity.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-.9f, .9f, 1f);
        }
        else if (rb.velocity.x <= -0.01f)
        {
            enemyGFX.localScale = new Vector3(.9f, .9f, 1f);
        }

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
            CreateSlimedust();
        }

        if (timeBtwShots <= 0)
        {
            if (reachedEndOfPAth == false)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            
        } else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }
}
