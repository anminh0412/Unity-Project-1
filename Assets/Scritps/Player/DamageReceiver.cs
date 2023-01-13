using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageReceiver : MonoBehaviour
{
    private float maxHealth;
    public float currentHealth;
    public float hpRecovery;
    public Animator Animation;
    public Text hpText;
    private string stringHpText;
    protected float takeDamePercent;

    void Start()
    {
        maxHealth = GetComponent<PlayerStatus>().maxHealth;
        hpRecovery = GetComponent<PlayerStatus>().hpRecovery;
        currentHealth = maxHealth;
        takeDamePercent = GetComponent<PlayerShieldController>().shieldIndex;
    }
    private void Update()
    {
        stringHpText = currentHealth.ToString("0");
        hpText.text = stringHpText;
        Healing();
        if (currentHealth < 0 || gameObject.transform.position.y < -10)
        {
            currentHealth = 0;
            Animation.SetBool("isDead", true);
            Debug.Log("chet thang bo m roi!!!");
            GetComponent<PlayerDeadEvend>().enabled = true;
        }
    }
    public virtual void ReceiveDamege(float damege)
    {
        if (GameObject.Find("shield"))
        {
            currentHealth -= damege * takeDamePercent;
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("playerHurt");
        }
        else
        {
            currentHealth -= damege;
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("playerHurt");
        }    
    }
    void Healing()
    {
        if (currentHealth < maxHealth && currentHealth > 0)
        {
            currentHealth = currentHealth + hpRecovery * Time.deltaTime;
        }
    }
}
