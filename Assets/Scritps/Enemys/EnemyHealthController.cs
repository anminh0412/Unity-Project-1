using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField]
    float enemyHealth;
    public float maxHealth;
    public float currentHealth;
    public bool isDead = false;
    public EnemyHeathBar healthBar;
    public Animator enemyAnimation;
    public float hpRecovery;
    void Start()
    {
        enemyHealth = maxHealth;
        currentHealth = enemyHealth;
        healthBar.SetHealth(currentHealth, maxHealth);
    }
    private void Update()
    {
        Healing();
        healthBar.SetHealth(currentHealth, maxHealth);
        if (currentHealth < 0)
        {
            enemyAnimation.SetBool("isDead", true);
            GetComponent<DeadEvend>().enabled = true;
            isDead = true;
        }
    }
    
    public virtual void TakeDame(float damege)
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
