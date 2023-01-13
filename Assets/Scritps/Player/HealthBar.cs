using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float maxHealth;
    public float health;
    private Image healthBar;
    void Start()
    {
        healthBar = GetComponent<Image>();
        maxHealth = GameObject.Find("player").GetComponent<PlayerStatus>().maxHealth;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
       healthBar.fillAmount = health / maxHealth;
       health = GameObject.Find("player").GetComponent<DamageReceiver>().currentHealth;
    }
}
