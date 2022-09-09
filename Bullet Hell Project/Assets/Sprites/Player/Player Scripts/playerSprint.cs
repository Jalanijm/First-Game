using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerSprint : MonoBehaviour
{
    public float totalStamina;
    public float stamina;
    public Slider staminaBar;

    // Start is called before the first frame update
    void Awake()
    {
        staminaBar.value = stamina;
        staminaBar.maxValue = totalStamina;
        stamina = totalStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1) && staminaBar.value > 0 && PauseMenu.GameIsPaused == false && PauseMenu.PlayerIsDead == false)
        {
            AttachPoint.isRunning = true;
            staminaBar.value -= 1.5f;
        }
        else
        {
            AttachPoint.isRunning = false;
        }

        if (staminaBar.value < 120 && !Input.GetMouseButton(1) && !Input.GetKey(KeyCode.Space) && PauseMenu.GameIsPaused == false && PauseMenu.PlayerIsDead == false)
        {
            staminaBar.value += 0.5f;
        }


        if (Input.GetKey(KeyCode.Space) && staminaBar.value >= 120 && PauseMenu.GameIsPaused == false && PauseMenu.PlayerIsDead == false)
        {
            AttachPoint.usingShield = true;
            var Sound = GameObject.FindGameObjectWithTag("SoundEffects").GetComponent<SoundEffects>();
            Sound.ShieldSound.Play();
            FunctionTimer.Create(PlayerShield, 1.05f);
            staminaBar.value -= 120f;
        }


    }

    void PlayerShield()
    {
        AttachPoint.usingShield = false;
    }

}
