using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBehaviour : MonoBehaviour
{
    public float offset;

    private GameObject player;
    private float rotX;
    private float rotY;
    private bool gunFacingRight;
    private bool gunFacingLeft;

    public Text WeaponSelect;

    public Animator gunAnimator;

    private SpriteRenderer spriteRenderer;
    public SpriteRenderer muzzleRenderer;

    public float fireRate;
    float ReadyForNextShot;
    public float BulletSpeed;
    public GameObject Bullet;
    public GameObject Gun;
    public GameObject Muzzle;
    public Transform ShootPoint;
    public Vector3 BulletOffSet = new Vector3(0, 0.1f, 0);

    // Start is called before the first frame update
    void Start()
    {
        //Find Gun Object and Gun SpriteRenderer
        spriteRenderer = Gun.GetComponent<SpriteRenderer>();
        muzzleRenderer = Muzzle.GetComponent<SpriteRenderer>();
        GameObject Aim = GameObject.FindWithTag("Aim");
        GameObject Bullet = GameObject.FindWithTag("Bullet");
    }

    //Create Bullet
    void shoot()
    {
        gunAnimator.enabled = true;
        GameObject BulletIns = Instantiate(Bullet, ShootPoint.position + BulletOffSet, ShootPoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * BulletSpeed);
        gunAnimator.SetTrigger("Shooting");
        Destroy(BulletIns, 3);
    }

    // Update is called once per frame
    void Update()
    {
        //Rotation
        if (PauseMenu.GameIsPaused == false && PauseMenu.PlayerIsDead == false)
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);

            if (rotz < 90 && rotz > -90)
            {
                Debug.Log("Facing Right");
                //Flip
                spriteRenderer.flipY = false;
                muzzleRenderer.flipY = false;


            }
            else
            {
                Debug.Log("Facing Left");
                //Flip
                spriteRenderer.flipY = true;
                muzzleRenderer.flipY = true;


            }
        }

        //Rate of Fire
        if (Input.GetMouseButton(0))
        {
            if(Time.time > ReadyForNextShot && PauseMenu.GameIsPaused == false && PauseMenu.PlayerIsDead == false)
            {
                ReadyForNextShot = Time.time + 1 / fireRate;
                shoot();
                
                var Sound = GameObject.FindGameObjectWithTag("SoundEffects").GetComponent<SoundEffects>();
                Sound.ShootEffect.Play();
            }
            
        }


    }

}
