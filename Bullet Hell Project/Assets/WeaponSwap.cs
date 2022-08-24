using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwap : MonoBehaviour
{
    public int SelectedWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = SelectedWeapon;

        if (Input.GetKeyDown("1") && PauseMenu.GameIsPaused == false && PauseMenu.PlayerIsDead == false) {
            if (SelectedWeapon >= transform.childCount - 1)
            {
                SelectedWeapon = 0;
            } else
            {
                SelectedWeapon++;
            }
        } 
        
        if (Input.GetKeyDown(KeyCode.Q) && PauseMenu.GameIsPaused == false && PauseMenu.PlayerIsDead == false)
        {
            if (SelectedWeapon <= 0)
            {
                SelectedWeapon = transform.childCount - 1;
            } else
            {
                SelectedWeapon--;
            }
        }

        if (previousSelectedWeapon != SelectedWeapon)
        {
            FunctionTimer.Create(SelectWeapon, 0.65f);
        }

    }

    void SelectWeapon ()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == SelectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                weapon.gameObject.GetComponent<WeaponBehaviour>().muzzleRenderer.enabled = true;
                weapon.gameObject.GetComponent<WeaponBehaviour>().gunAnimator.enabled = true;
                weapon.gameObject.GetComponent<WeaponBehaviour>().WeaponSelect.GetComponent<Animator>().SetTrigger("WeaponSelect");
            } else
            {
                weapon.gameObject.GetComponent<WeaponBehaviour>().muzzleRenderer.enabled = false;
                
                weapon.gameObject.SetActive(false);
                weapon.gameObject.GetComponent<WeaponBehaviour>().gunAnimator.SetTrigger("Idle");
                weapon.gameObject.GetComponent<WeaponBehaviour>().WeaponSelect.GetComponent<Animator>().SetTrigger("NoWeaponSelect");
            }
            i++;
        }
    }

}
