using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthController : MonoBehaviour
{
    [SerializeField]
    float enemyHealth;
    public float maxHealth;
    public float currentHealth;
    public bool isDead;
    public EnemyHeathBar healthBar;
    //public Animator enemyAnimation;
    public float hpRecovery;
    public Animator bossAnimation;
    void Start()
    {
        enemyHealth = maxHealth;
        currentHealth = enemyHealth;
        healthBar.SetHealth(currentHealth, maxHealth);
        bossAnimation = gameObject.gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        healthBar.SetHealth(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            bossAnimation.SetBool("isDead", true);
            GetComponent<BossDeadEvent>().enabled = true;
            isDead = true;
        }
    }

    public virtual void BossTakeDame(float damege)
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        currentHealth -= damege;
        Invoke("RevertColor", 0.1f);
    }
    void RevertColor()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    void Healing()
    {
        if (currentHealth < maxHealth && currentHealth > 0)
        {
            currentHealth = currentHealth + hpRecovery * Time.deltaTime;
        }
    }
}
