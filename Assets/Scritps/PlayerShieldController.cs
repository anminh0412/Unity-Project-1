using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldController : MonoBehaviour
{
    public GameObject playerShield;
    public GameObject playerOnShield;
    public Animator playerAnimation;
    public float shieldIndex;
    public bool onShield;
    public bool hadShield;

    float elapsed = 0f;

    void Start()
    {
        playerAnimation = GetComponent<Animator>();
        playerShield.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.S) && hadShield == true || Input.GetKey(KeyCode.DownArrow) && hadShield == true)
        {
            ShieldOn();
            if (!GameObject.Find("SoundManager").GetComponent<SoundManager>().ShiedlAudioSrc.isPlaying)
            {
                GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("playerShield");
            }
        }
        else 
        { 
            ShieldOff();
            GameObject.Find("SoundManager").GetComponent<SoundManager>().ShiedlAudioSrc.Stop();
        }
    }
    void ShieldOn()
    {
        onShield = true;
        playerShield.SetActive(true);
        playerOnShield.SetActive(true);
        playerAnimation.SetBool("isCrouch", true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<PlayerShoot>().enabled = false;
        GetComponent<SummonMinion>().enabled = false;
        GetComponent<SummonWeapon>().enabled = false;
        //GetComponent<WeaponSkills>().enabled = false;
        elapsed += Time.deltaTime;
        if (elapsed >= 0.1f)
        {
           elapsed = elapsed % 0.1f;
           GetComponent<DamageReceiver>().currentHealth -= 5f;
        }
    }
    void ShieldOff()
    {
        onShield = false;
        playerShield.SetActive(false);
        playerOnShield.SetActive(false);
        playerAnimation.SetBool("isCrouch", false);
        GetComponent<PlayerController>().enabled = true;
        GetComponent<PlayerShoot>().enabled = true;
        GetComponent<SummonMinion>().enabled = true;
        GetComponent<SummonWeapon>().enabled = true;
        //GetComponent<WeaponSkills>().enabled = true;
    }
}
