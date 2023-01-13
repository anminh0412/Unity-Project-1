using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollide : MonoBehaviour
{
    public float Damage;
    public float currentDamage;
    private void Start()
    {
        Damage = GameObject.Find("Weapon").GetComponent<WeaponStatus>().Damage;
        currentDamage = Damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "boss")
        {
            Debug.Log("Target was Hit!");
            GameObject.Find("boss").GetComponent<BossHealthController>().BossTakeDame(currentDamage);
        }
        EnemyHealthController damageReceiver = collision.GetComponent<EnemyHealthController>();
        damageReceiver.TakeDame(currentDamage);
    } 
}
