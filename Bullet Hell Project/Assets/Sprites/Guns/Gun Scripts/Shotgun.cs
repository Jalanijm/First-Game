using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public float offset;

    private GameObject player;
    private float rotX;
    private float rotY;
    private bool gunFacingRight;
    private bool gunFacingLeft;

    public GameObject Flashlight;

    public Animator gunAnimator;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer muzzleRenderer;

    public float fireRate;
    float ReadyForNextShot;
    public float BulletSpeed;
    public GameObject Bullet;
    public Transform ShootPoint;
    public Vector3 BulletOffSet = new Vector3(0, 0.1f, 0);
    public Vector3 BulletOffSet2 = new Vector3(0, 0.1f, 0);
    public Vector3 BulletOffSet3 = new Vector3(0, 0.1f, 0);

    // Start is called before the first frame update
    void Start()
    {
        //Find Gun Object and Gun SpriteRenderer
        GameObject Gun = GameObject.FindWithTag("Gun");
        spriteRenderer = Gun.GetComponent<SpriteRenderer>();
        GameObject Muzzle = GameObject.FindWithTag("GunEndpoint");
        muzzleRenderer = Muzzle.GetComponent<SpriteRenderer>();
        GameObject Aim = GameObject.FindWithTag("Aim");
        GameObject Bullet = GameObject.FindWithTag("Bullet");
    }

    //Create Bullet
    void shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, ShootPoint.position + BulletOffSet, ShootPoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * BulletSpeed);

        gunAnimator.SetTrigger("Shooting");
        Destroy(BulletIns, 3);
    }

    // Update is called once per frame
    void Update()
    {
        //Rotation
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

        //Rate of Fire
        if (Input.GetMouseButton(0))
        {
            if (Time.time > ReadyForNextShot)
            {
                ReadyForNextShot = Time.time + 1 / fireRate;
                shoot();
            }

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!Flashlight.activeInHierarchy)
            {
                Flashlight.SetActive(true);
            }
            else if (Flashlight.activeInHierarchy)
            {
                Flashlight.SetActive(false);
            }
        }


    }

}
